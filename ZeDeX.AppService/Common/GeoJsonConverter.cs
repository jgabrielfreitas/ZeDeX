using NetTopologySuite.IO;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;

namespace ZeDeX.AppService.Common
{
    public class GeoJsonConverter : GeometryConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JsonSerializer geojson = GeoJsonSerializer.CreateDefault();
            geojson.Serialize(writer, value);
        }
    }
}
