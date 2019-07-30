using System;
using System.Collections.Generic;
using GeoAPI.Geometries;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;

namespace ZeDeX.AppService.Common
{
    public class GeoJsonConverter : GeometryConverter
    {
        private readonly IGeometryFactory _factory;
        private readonly JsonSerializer _geoJsonSerializer;

        public GeoJsonConverter() : this(GeographyFactory.CreateFactory())
        {
            _geoJsonSerializer = GeoJsonSerializer.CreateDefault();
        }

        public GeoJsonConverter(IGeometryFactory geometryFactory)
        {
            _factory = geometryFactory;
            _geoJsonSerializer = GeoJsonSerializer.CreateDefault();
        }

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            reader.Read();
            if (!(reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "type"))
                throw new ArgumentException("invalid tokentype: " + reader.TokenType);
            reader.Read();
            if (reader.TokenType != JsonToken.String)
                throw new ArgumentException("invalid tokentype: " + reader.TokenType);
            GeoJsonObjectType geometryType = (GeoJsonObjectType)Enum.Parse(typeof(GeoJsonObjectType), (string)reader.Value);
            switch (geometryType)
            {
                case GeoJsonObjectType.Point:
                    Coordinate coordinate = _geoJsonSerializer.Deserialize<Coordinate>(reader);
                    return _factory.CreatePoint(coordinate);

                case GeoJsonObjectType.LineString:
                    Coordinate[] coordinates = _geoJsonSerializer.Deserialize<Coordinate[]>(reader);
                    return _factory.CreateLineString(coordinates);

                case GeoJsonObjectType.Polygon:
                    List<Coordinate[]> coordinatess = _geoJsonSerializer.Deserialize<List<Coordinate[]>>(reader);
                    return CreatePolygon(coordinatess);

                case GeoJsonObjectType.MultiPoint:
                    coordinates = _geoJsonSerializer.Deserialize<Coordinate[]>(reader);
                    return _factory.CreateMultiPoint(coordinates);

                case GeoJsonObjectType.MultiLineString:
                    coordinatess = _geoJsonSerializer.Deserialize<List<Coordinate[]>>(reader);
                    List<ILineString> strings = new List<ILineString>();
                    for (int i = 0; i < coordinatess.Count; i++)
                        strings.Add(_factory.CreateLineString(coordinatess[i]));
                    return _factory.CreateMultiLineString(strings.ToArray());

                case GeoJsonObjectType.MultiPolygon:
                    List<List<Coordinate[]>> coordinatesss = _geoJsonSerializer.Deserialize<List<List<Coordinate[]>>>(reader);
                    List<IPolygon> polygons = new List<IPolygon>();
                    foreach (List<Coordinate[]> coordinateses in coordinatesss)
                        polygons.Add(CreatePolygon(coordinateses));
                    return _factory.CreateMultiPolygon(polygons.ToArray());

                case GeoJsonObjectType.GeometryCollection:
                    List<IGeometry> geoms = _geoJsonSerializer.Deserialize<List<IGeometry>>(reader);
                    return _factory.CreateGeometryCollection(geoms.ToArray());
            }
            return null;
        }

        private IPolygon CreatePolygon(IList<Coordinate[]> coordinatess)
        {
            ILinearRing shell = _factory.CreateLinearRing(coordinatess[0]);
            List<ILinearRing> rings = new List<ILinearRing>();
            for (int i = 1; i < coordinatess.Count; i++)
                rings.Add(_factory.CreateLinearRing(coordinatess[i]));
            return _factory.CreatePolygon(shell, rings.ToArray());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            _geoJsonSerializer.Serialize(writer, value);
        }
    }
}
