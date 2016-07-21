using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Furnace.Core.Play;
using Furnace.Core.Play.Kernal;

namespace Furnace.Core.Requet.Play
{
    public class WebRequestMiddleware : IFurnaceMiddleware
    {
        private readonly IQueryHandler<WebRequestQuery, WebRequestQueryResult> _queryHandler;

        public WebRequestMiddleware(IQueryHandler<WebRequestQuery, WebRequestQueryResult> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        public int Weight => 0;

        public Task Invoke(IDictionary<string, object> environment)
        {
            var responseText = "Hello World via OWIN";
            var responseBytes = Encoding.UTF8.GetBytes(responseText);

            // OWIN Environment Keys: http://owin.org/spec/spec/owin-1.0.0.html
            var responseStream = (Stream)environment["owin.ResponseBody"];
            var responseHeaders = (IDictionary<string, string[]>)environment["owin.ResponseHeaders"];

            responseHeaders["Content-Length"] = new[] { responseBytes.Length.ToString(CultureInfo.InvariantCulture) };
            responseHeaders["Content-Type"] = new[] { "text/plain" };

            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}
