using TelegramExportProcessor;

var chatHistory = await ExportParser.ParseChatExportFile(args[0]);
Console.WriteLine($"Messages parsed : {chatHistory.Messages.Count}");
