// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;

var content = File.ReadAllText(args[0]);
var jsonString = JsonSerializer.Deserialize(content, SourceGenerationContext.Default.ChatExport);

public class ChatExport
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Id { get; set; }
    public List<ChatMessage> Messages { get; set; }
}

public class ChatMessage
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }

    [JsonPropertyName("date_unixtime")]
    public long DateUnixTime { get; set; }
    public DateTime? Edited { get; set; }

    [JsonPropertyName("edited_unixtime")]
    public long? EditedUnixTime { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? From { get; set; }

    [JsonPropertyName("from_id")]
    public string? FromId { get; set; }

    [JsonPropertyName("text_entities")]
    public List<TextEntity> TextEntities { get; set; }
    public List<Reaction> Reactions { get; set; }
}
public class TextEntity
{
    public string Text { get; set; }
    public string Type { get; set; }
}

public class Reaction
{
    public int Count { get; set; }
    public string Type { get; set; }
    public string Emoji { get; set; }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(ChatExport))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
