using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Newtonsoft.Json.JsonConverter(typeof(NetTopologySuite.IO.Converters.GeometryConverter))]
        public MultiPolygon coverageArea { get; set; }
        [Required]
        [Newtonsoft.Json.JsonConverter(typeof(NetTopologySuite.IO.Converters.GeometryConverter))]
        public Point address { get; set; }
    }
}
