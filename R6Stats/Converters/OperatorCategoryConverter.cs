using Newtonsoft.Json;
using R6Stats.Constants;
using R6Stats.Enums;
using System;

namespace R6Stats.Converters
{
    internal class OperatorCategoryConverter : JsonConverter<EOperatorCategory>
    {
        public override void WriteJson(JsonWriter writer, EOperatorCategory value, JsonSerializer serializer)
        {
            switch (value)
            {
                case EOperatorCategory.Defense:
                    writer.WriteValue(ApiOperators.Defense);
                    break;
                case EOperatorCategory.Attack:
                    writer.WriteValue(ApiOperators.Attack);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public override EOperatorCategory ReadJson(JsonReader reader, Type objectType, EOperatorCategory existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return reader.Value switch
            {
                ApiOperators.Defense => EOperatorCategory.Defense,
                ApiOperators.Attack => EOperatorCategory.Attack,
                _ => throw new Exception($"Couldn't convert {reader.ValueType} to {objectType}")
            };
        }
    }
}
