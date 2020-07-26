using Newtonsoft.Json;
using R6Stats.Constants;
using R6Stats.Enums;
using System;

namespace R6Stats.Converters
{
    internal class RegionConverter : JsonConverter<ERegion>
    {
        public override void WriteJson(JsonWriter writer, ERegion value, JsonSerializer serializer)
        {
            switch (value)
            {
                case ERegion.Eu:
                    writer.WriteValue(ApiRanks.Emea);
                    break;
                case ERegion.Na:
                    writer.WriteValue(ApiRanks.Ncsa);
                    break;
                case ERegion.Asia:
                    writer.WriteValue(ApiRanks.Apac);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public override ERegion ReadJson(JsonReader reader, Type objectType, ERegion existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return reader.Value switch
            {
                ApiRanks.Emea => ERegion.Eu,
                ApiRanks.Ncsa => ERegion.Na,
                ApiRanks.Apac => ERegion.Asia,
                _ => throw new Exception($"Couldn't convert {reader.ValueType} to {objectType}")
            };
        }
    }
}
