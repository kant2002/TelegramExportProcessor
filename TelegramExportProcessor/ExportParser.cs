using System.Text.Json;

namespace TelegramExportProcessor;

public class ExportParser
{
    public static async Task<ChatExport?> ParseChatExportFile(string file)
    {
        var content = await File.ReadAllTextAsync(file);
        return ParseChatExport(content);
    }

    public static ChatExport? ParseChatExport(string content)
    {
        if (content.EndsWith("  }"))
        {
            content += "]}";
        }
        var chatHistory = JsonSerializer.Deserialize(content, SourceGenerationContext.Default.ChatExport);
        return chatHistory;
    }
}
