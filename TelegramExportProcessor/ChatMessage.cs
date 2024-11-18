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

    [JsonPropertyName("forwarded_from")]
    public string? ForwardedFrom { get; set; }

    public string? Photo { get; set; }

    public string? File { get; set; }

    [JsonPropertyName("file_name")]
    public string? Filename { get; set; }

    public string? Thumbnail { get; set; }

    [JsonPropertyName("media_type")]
    public string? MediaType { get; set; }

    [JsonPropertyName("mime_type")]
    public string? MimeType { get; set; }

    [JsonPropertyName("duration_seconds")]
    public int? DurationSeconds { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    [JsonPropertyName("from_id")]
    public string? FromId { get; set; }

    [JsonPropertyName("text_entities")]
    public List<TextEntity> TextEntities { get; set; }

    public List<Reaction>? Reactions { get; set; }
}
