using Newtonsoft.Json;
using R6Stats.Constants;
using R6Stats.Enums;
using System;

namespace R6Stats.Converters
{
    internal class PlatformTypeConverter : JsonConverter<EPlatformType>
    {
        public override void WriteJson(JsonWriter writer, EPlatformType value, JsonSerializer serializer)
        {
            switch (value)
            {
                case EPlatformType.Uplay:
                    writer.WriteValue(ApiCommon.UplayString);
                    break;
                case EPlatformType.Xbox:
                    writer.WriteValue(ApiCommon.XboxString);
                    break;
                case EPlatformType.Playstation:
                    writer.WriteValue(ApiCommon.PlaystationString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public override EPlatformType ReadJson(JsonReader reader, Type objectType, EPlatformType existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return reader.Value switch
            {
                ApiCommon.UplayString => EPlatformType.Uplay,
                ApiCommon.XboxString => EPlatformType.Xbox,
                ApiCommon.PlaystationString => EPlatformType.Playstation,
                _ => throw new Exception($"Couldn't convert {reader.ValueType} to {objectType}")
            };
        }
    }
}
