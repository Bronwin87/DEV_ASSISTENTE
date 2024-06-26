using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASSISTENTE.Persistence.Configuration.Converters;

internal sealed class EnumConverter<TEnum>()
    : ValueConverter<TEnum, string>(
        v => v.ToString(),
        v => (TEnum)Enum.Parse(typeof(TEnum), v))
    where TEnum : Enum;