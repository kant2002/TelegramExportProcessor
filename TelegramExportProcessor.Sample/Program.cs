using TelegramExportProcessor;

var exportFile = args[0];
var chatHistory = await ExportParser.ParseChatExportFile(exportFile);
if (chatHistory is null)
{
    Console.WriteLine($"Cannot parse file {exportFile}");
    return;
}

Console.WriteLine($"Messages parsed : {chatHistory.Messages.Count}");
Console.WriteLine($"Entry types:");
foreach (var entryType in chatHistory.Messages.SelectMany(_ => _.TextEntities.Select(_ => _.Type)).Distinct())
{
    Console.WriteLine($"Entry type : {entryType}");
}

Console.WriteLine($"Message types:");
foreach (var messageType in chatHistory.Messages.Select(_ => _.Type).Distinct())
{
    Console.WriteLine($"Message type : {messageType}");
}

Console.WriteLine($"Reaction types:");
foreach (var reactionType in chatHistory.Messages.Where(_ => _.Reactions is not null).SelectMany(_ => _.Reactions!.Select(_ => _.Type)).Distinct())
{
    Console.WriteLine($"Reaction type : {reactionType}");
}
