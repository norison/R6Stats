using Newtonsoft.Json;
using R6Stats.Constants;
using R6Stats.Enums;
using System;

namespace R6Stats.Converters
{
    internal class PlatformTypeConverter : JsonConverter<EPlatform>
    {
        public override void WriteJson(JsonWriter writer, EPlatform value, JsonSerializer serializer)
        {
            switch (value)
            {
                case EPlatform.Uplay:
                    writer.WriteValue(ApiCommon.UplayString);
                    break;
                case EPlatform.Xbox:
                    writer.WriteValue(ApiCommon.XboxString);
                    break;
                case EPlatform.Playstation:
                    writer.WriteValue(ApiCommon.PlaystationString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public override EPlatform ReadJson(JsonReader reader, Type objectType, EPlatform existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return reader.Value switch
            {
                ApiCommon.UplayString => EPlatform.Uplay,
                ApiCommon.XboxString => EPlatform.Xbox,
                ApiCommon.PlaystationString => EPlatform.Playstation,
                _ => throw new Exception($"Couldn't convert {reader.ValueType} to {objectType}")
            };
        }
    }
}
