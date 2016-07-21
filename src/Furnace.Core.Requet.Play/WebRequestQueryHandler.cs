using Furnace.Core.Play.Kernal;

namespace Furnace.Core.Requet.Play
{
    public class WebRequestQueryHandler : IQueryHandler<WebRequestQuery, WebRequestQueryResult>
    {
        public WebRequestQueryResult Handle(WebRequestQuery query)
        {
            return new WebRequestQueryResult { Body = query.Path }; 
        }
    }
}
