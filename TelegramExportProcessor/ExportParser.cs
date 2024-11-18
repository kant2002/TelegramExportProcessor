using System.Text.Json;

namespace TelegramExportProcessor;

public sealed class ExportParser
{
    public static async Task<ChatExport?> ParseChatExportFileAsync(string file)
    {
        var content = await File.ReadAllTextAsync(file);

        return ParseChatExport(content);
    }

    public static ChatExport? ParseChatExportFile(string file)
    {
        var content = File.ReadAllText(file);

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
