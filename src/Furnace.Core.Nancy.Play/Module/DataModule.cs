using Furnace.Core.Data.Play.Query.Configuration.MetaTypeMaping;
using Furnace.Core.Nancy.Play.Module.JSON;
using Furnace.Core.Play.Query;
using Newtonsoft.Json;

namespace Furnace.Core.Nancy.Play.Module
{
    public sealed class DataModule: NancyFurnaceModule
    {
        private readonly IQueryHandler<MetaTypeMapingQuery, MetaTypeMapingQueryResult> _metaTypeMapingQueryHandler;

        public DataModule(IQueryHandler<MetaTypeMapingQuery, MetaTypeMapingQueryResult> metaTypeMapingQueryHandler)
        {
            _metaTypeMapingQueryHandler = metaTypeMapingQueryHandler;
            Get("/api/v1/meta-type-maping", parameters => GetMetaTypeMaping());
        }

        private string GetMetaTypeMaping()
        {
            var mapings = _metaTypeMapingQueryHandler.Handle(new MetaTypeMapingQuery());
            return JsonConvert.SerializeObject(mapings, Formatting.Indented, new MetaTypeMapingSerializer());
        }
    }
}
