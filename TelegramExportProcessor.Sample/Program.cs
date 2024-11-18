using TelegramExportProcessor;

var exportFile = args[0];
var chatHistory = await ExportParser.ParseChatExportFile(exportFile);
if (chatHistory is null)
{
    Console.WriteLine($"Cannot parse file {exportFile}");
    return;
}

var messages = chatHistory.Messages;

PrintEntityTypes(messages);
FindAllLinks(messages);
FindTgChannels(messages);
void FindAllLinks(IEnumerable<ChatMessage> entities)
{
    foreach (var entryType in messages.SelectMany(_ => _.TextEntities.Where(_ => _.Type is "link" or "text_link").Select(_ => _.Href ?? _.Text)).Distinct())
    {
        Console.WriteLine($"Links: {entryType}");
    }
}

string ExtractTelegramChannelLink(string telegramLink)
    => "https://" + string.Join("/", telegramLink.Replace("http://", "").Replace("https://", "").Split("/").Take(2));

void FindTgChannels(IEnumerable<ChatMessage> entities)
{
    var links = messages.SelectMany(_ => _.TextEntities.Where(_ => _.Type is "link" or "text_link").Select(_ => _.Href ?? _.Text)).Distinct();
    foreach (var entryType in links.Where(_ => _.Contains("t.me/")).Select(ExtractTelegramChannelLink).Distinct().Order())
    {
        Console.WriteLine($"{entryType}");
    }
}

void PrintEntityTypes(IEnumerable<ChatMessage> entities)
{
    Console.WriteLine($"Messages parsed : {messages.Count}");
    Console.WriteLine($"Entry types:");
    foreach (var entryType in messages.SelectMany(_ => _.TextEntities.Select(_ => _.Type)).Distinct().Order())
    {
        Console.WriteLine($"Entry type : {entryType}");
    }

    Console.WriteLine($"Message types:");
    foreach (var messageType in messages.Select(_ => _.Type).Distinct().Order())
    {
        Console.WriteLine($"Message type : {messageType}");
    }

    Console.WriteLine($"Reaction types:");
    foreach (var reactionType in messages.Where(_ => _.Reactions is not null).SelectMany(_ => _.Reactions!.Select(_ => _.Type)).Distinct().Order())
    {
        Console.WriteLine($"Reaction type : {reactionType}");
    }
}
