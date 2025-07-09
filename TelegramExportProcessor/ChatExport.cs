namespace TelegramExportProcessor;

public class ChatExport
{
    public string Name { get; set; }

    public string Type { get; set; }

    public long Id { get; set; }

    public List<ChatMessage> Messages { get; set; }
}
