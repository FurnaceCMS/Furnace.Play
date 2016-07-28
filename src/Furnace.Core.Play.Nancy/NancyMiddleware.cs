using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Furnace.Core.Play.Middleware;
using Nancy;
using Nancy.IO;
using Nancy.Owin;
using System.Linq;
using Nancy.Helpers;

namespace Furnace.Core.Play.Nancy
{
    public class NancyMiddleware: FurnaceMiddleware
    {
        public const string RequestEnvironmentKey = "OWIN_REQUEST_ENVIRONMENT";

        private readonly NancyOptions _options;

        public NancyMiddleware(NancyOptions options)
        {
            _options = options;
        }
  
        public override int Weight => -1;


        public override async Task Invoke(IDictionary<string, object> environment)
        {
            var engine = _options.Bootstrapper.GetEngine();

            var owinRequestMethod = Get<string>(environment, "owin.RequestMethod");
            var owinRequestScheme = Get<string>(environment, "owin.RequestScheme");
            var owinRequestHeaders = Get<IDictionary<string, string[]>>(environment, "owin.RequestHeaders");
            var owinRequestPathBase = Get<string>(environment, "owin.RequestPathBase");
            var owinRequestPath = Get<string>(environment, "owin.RequestPath");
            var owinRequestQueryString = Get<string>(environment, "owin.RequestQueryString");
            var owinRequestBody = Get<Stream>(environment, "owin.RequestBody");
            var owinRequestProtocol = Get<string>(environment, "owin.RequestProtocol");
            var owinCallCancelled = Get<CancellationToken>(environment, "owin.CallCancelled");
            var owinRequestHost = GetHeader(owinRequestHeaders, "Host") ?? Dns.GetHostName();
            var owinUser = GetUser(environment);

            X509Certificate2 certificate = null;
            if (_options.EnableClientCertificates)
            {
                var clientCertificate =
                    new X509Certificate2(
                        Get<X509Certificate>(environment, "ssl.ClientCertificate")
                            .Export(X509ContentType.Cert));
                certificate = clientCertificate ?? null;
            }

            var serverClientIp = Get<string>(environment, "server.RemoteIpAddress");

            var url = CreateUrl(owinRequestHost, owinRequestScheme, owinRequestPathBase, owinRequestPath,
                owinRequestQueryString);

            var nancyRequestStream = new RequestStream(owinRequestBody, ExpectedLength(owinRequestHeaders),
                StaticConfiguration.DisableRequestStreamSwitching ?? false);

            var nancyRequest = new Request(
                owinRequestMethod,
                url,
                nancyRequestStream,
                owinRequestHeaders.ToDictionary(kv => kv.Key, kv => (IEnumerable<string>) kv.Value,
                    StringComparer.OrdinalIgnoreCase),
                serverClientIp,
                certificate,
                owinRequestProtocol);

            var nancyContext = await engine.HandleRequest(
                nancyRequest,
                StoreEnvironment(environment, owinUser),
                owinCallCancelled).ConfigureAwait(false);

            await
                RequestComplete(nancyContext, environment, _options.PerformPassThrough)
                    .ConfigureAwait(false);

        }



        private static T Get<T>(IDictionary<string, object> env, string key)
        {
            object value;
            return env.TryGetValue(key, out value) && value is T ? (T)value : default(T);
        }

        private static ClaimsPrincipal GetUser(IDictionary<string, object> environment)
        {
            // OWIN 1.1
            object user;
            if (environment.TryGetValue("owin.RequestUser", out user))
            {
                return user as ClaimsPrincipal;
            }

            // check for Katana User
            if (environment.TryGetValue("server.User", out user))
            {
                return user as ClaimsPrincipal;
            }
            return null;
        }

        private static Url CreateUrl(
            string owinRequestHost,
            string owinRequestScheme,
            string owinRequestPathBase,
            string owinRequestPath,
            string owinRequestQueryString)
        {
            int? port = null;

            var hostnameParts = owinRequestHost.Split(':');
            if (hostnameParts.Length == 2)
            {
                owinRequestHost = hostnameParts[0];

                int tempPort;
                if (int.TryParse(hostnameParts[1], out tempPort))
                {
                    port = tempPort;
                }
            }

            var url = new Url
            {
                Scheme = owinRequestScheme,
                HostName = owinRequestHost,
                Port = port,
                BasePath = owinRequestPathBase,
                Path = owinRequestPath,
                Query = owinRequestQueryString,
            };
            return url;
        }

        private static long ExpectedLength(IDictionary<string, string[]> headers)
        {
            var header = GetHeader(headers, "Content-Length");
            if (string.IsNullOrWhiteSpace(header))
                return 0;

            int contentLength;
            return int.TryParse(header, NumberStyles.Any, CultureInfo.InvariantCulture, out contentLength) ? contentLength : 0;
        }

        private static string GetHeader(IDictionary<string, string[]> headers, string key)
        {
            string[] value;
            return headers.TryGetValue(key, out value) && value != null ? string.Join(",", value.ToArray()) : null;
        }

        private static Func<NancyContext, NancyContext> StoreEnvironment(IDictionary<string, object> environment, ClaimsPrincipal user)
        {
            return context =>
            {
                context.CurrentUser = user;
                environment["nancy.NancyContext"] = context;
                context.Items[RequestEnvironmentKey] = environment;
                return context;
            };
        }

        private static Task RequestComplete(
           NancyContext context,
           IDictionary<string, object> environment,
           Func<NancyContext, bool> performPassThrough)
        {
            var owinResponseHeaders = Get<IDictionary<string, string[]>>(environment, "owin.ResponseHeaders");
            var owinResponseBody = Get<Stream>(environment, "owin.ResponseBody");

            var nancyResponse = context.Response;
            if (!performPassThrough(context))
            {
                environment["owin.ResponseStatusCode"] = (int)nancyResponse.StatusCode;

                if (nancyResponse.ReasonPhrase != null)
                {
                    environment["owin.ResponseReasonPhrase"] = nancyResponse.ReasonPhrase;
                }

                foreach (var responseHeader in nancyResponse.Headers)
                {
                    owinResponseHeaders[responseHeader.Key] = new[] { responseHeader.Value };
                }

                if (!string.IsNullOrWhiteSpace(nancyResponse.ContentType))
                {
                    owinResponseHeaders["Content-Type"] = new[] { nancyResponse.ContentType };
                }

                if (nancyResponse.Cookies != null && nancyResponse.Cookies.Count != 0)
                {
                    const string setCookieHeaderKey = "Set-Cookie";
                    string[] setCookieHeader = owinResponseHeaders.ContainsKey(setCookieHeaderKey)
                                                    ? owinResponseHeaders[setCookieHeaderKey]
                                                    : ArrayCache.Empty<string>();
                    owinResponseHeaders[setCookieHeaderKey] = setCookieHeader
                        .Concat(nancyResponse.Cookies.Select(cookie => cookie.ToString()))
                        .ToArray();
                }

                nancyResponse.Contents(owinResponseBody);
            }

            context.Dispose();

            return TaskHelpers.CompletedTask;
        }
    }
}
