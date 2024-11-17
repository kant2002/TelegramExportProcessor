// See https://aka.ms/new-console-template for more information
namespace TelegramExportProcessor;

public class ChatExport
{
    public string Name { get; set; }

    public string Type { get; set; }

    public int Id { get; set; }

    public List<ChatMessage> Messages { get; set; }
}
