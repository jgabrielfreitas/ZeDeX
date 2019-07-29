using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

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

    public class CoverageArea
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }
    }

    public class Address
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }

        private int latitudePosition = 0;
        private int longitudePosition = 1;
        public double GetLatitude() => coordinates.IndexOf(latitudePosition);
        public double GetLongitude() => coordinates.IndexOf(longitudePosition);
    }

    public class Pdv
    {
        public string document { get; set; }
        public string name { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(NetTopologySuite.IO.Converters.GeometryConverter))]
        public MultiPolygon coverageArea { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(NetTopologySuite.IO.Converters.GeometryConverter))]
        public Point address { get; set; }
        //public Address address { get; set; }
    }
}
