using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZeDeX.AppService.Common;

namespace ZeDeX.AppService.Partners.Command
{
    public class CreatePartnerCommand
    {
        [Required]
        public Owner owner { get; set; }
        [Required]
        public Pdv pdv { get; set; }
    }

    public class Owner
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
    }

    public class Pdv
    {
        [Required]
        public string document { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [JsonConverter(typeof(GeoJsonConverter))]
        public MultiPolygon coverageArea { get; set; }
        [Required]
        [JsonConverter(typeof(GeoJsonConverter))]
        public Point address { get; set; }
    }
}
