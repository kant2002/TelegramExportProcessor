// See https://aka.ms/new-console-template for more information

using System.Text.Json.Serialization;

namespace TelegramExportProcessor;

public class ChatMessage
{
    public int Id { get; set; }

    public string Type { get; set; }

    public DateTime Date { get; set; }

    [JsonPropertyName("date_unixtime")]
    public string DateUnixTime { get; set; }

    public DateTime? Edited { get; set; }

    [JsonPropertyName("edited_unixtime")]
    public string? EditedUnixTime { get; set; }

    public string? Title { get; set; }

    // public string? Text { get; set; }
    public string? From { get; set; }

    [JsonPropertyName("from_id")]
    public string? FromId { get; set; }

    [JsonPropertyName("text_entities")]
    public List<TextEntity> TextEntities { get; set; }

    public List<Reaction> Reactions { get; set; }
}
