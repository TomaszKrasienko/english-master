using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace english_master.DAL;

internal sealed class GuidValueConverter() : ValueConverter<Guid, string>(
    x => x.ToString(), value => Guid.Parse(value));