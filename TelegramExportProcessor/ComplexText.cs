using System.Text.Json.Serialization;

namespace TelegramExportProcessor;

[JsonConverter(typeof(ComplexTextJsonConverter))]
public class ComplexText
{
    public List<TextEntity> Parts { get; } = [];
}
