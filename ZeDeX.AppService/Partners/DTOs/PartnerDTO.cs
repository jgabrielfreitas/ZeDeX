using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ZeDeX.AppService.Common;

namespace ZeDeX.AppService.Partners.DTOs
{
    public class PartnerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string DocumentNumber { get; set; }
        [JsonConverter(typeof(GeoJsonConverter))]
        public Point Address { get; set; }
        [JsonConverter(typeof(GeoJsonConverter))]
        public MultiPolygon CoverageArea { get; set; }

    }
}
