using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeDeX.AppService.Partners.DTOs
{
    public class PartnerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        [JsonConverter(typeof(GeometryConverter))]
        public Point Address { get; set; }
        [JsonConverter(typeof(GeometryConverter))]
        public MultiPolygon CoverageArea { get; set; }

    }
}
