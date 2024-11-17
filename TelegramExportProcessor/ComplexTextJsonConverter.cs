using System.Text.Json;
using System.Text.Json.Serialization;

namespace TelegramExportProcessor;

internal class ComplexTextJsonConverter : JsonConverter<ComplexText>
{
    public override ComplexText Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        throw new NotImplementedException();

        // return DateTimeOffset.ParseExact(reader.GetString()!,
        //        "MM/dd/yyyy", CultureInfo.InvariantCulture);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ComplexText dateTimeValue,
        JsonSerializerOptions options)
    {
        throw new NotImplementedException();

        // writer.WriteStringValue(dateTimeValue.ToString(
        //        "MM/dd/yyyy", CultureInfo.InvariantCulture));
    }
}
