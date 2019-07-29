using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using ZeDeX.AppService.Common;

namespace ZeDeX.AppService.Partners.Command
{
    public class CreatePartnerCommand
    {
        public Owner owner { get; set; }
        public Pdv pdv { get; set; }
    }

    public class Owner
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class Pdv
    {
        public string document { get; set; }
        public string name { get; set; }
        [JsonConverter(typeof(GeoJsonConverter))]
        public MultiPolygon coverageArea { get; set; }
        [JsonConverter(typeof(GeoJsonConverter))]
        public Point address { get; set; }
    }
}
