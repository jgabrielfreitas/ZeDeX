using GeoAPI.Geometries;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeDeX.AppService.Common
{
    public class GeographyFactory
    {
        private const int SRID = 4326;

        public static IGeometryFactory CreateFactory() => NtsGeometryServices.Instance.CreateGeometryFactory(srid: SRID);
    }
}
