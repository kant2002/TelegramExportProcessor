namespace TelegramExportProcessor.Tests;

public class TestParsing
{
    [Test]
    public async Task ParseWrapper()
    {
        var content =
            """
            {
                "name": "Ринда моніторить",
                "type": "public_channel",
                "id": 1875486764,
                "messages": []
            }
            """;
        var result = ExportParser.ParseChatExport(content);

        await Assert.That(result).IsNotNull().And.HasMember(_ => _.Id).EqualTo(1875486764);
    }

    [Test]
    public async Task ParseSystemMessage()
    {
        var content =
            """
            {
                "name": "Ринда моніторить",
                "type": "public_channel",
                "id": 1875486764,
                "messages": [
                  {
                     "id": 1,
                     "type": "service",
                     "date": "2023-04-04T03:06:29",
                     "date_unixtime": "1680559589",
                     "actor": "Ринда моніторить",
                     "actor_id": "channel1875486764",
                     "action": "create_channel",
                     "title": "GDZ UA",
                     "text": "",
                     "text_entities": []
                    }
                ]
            }
            """;
        var result = ExportParser.ParseChatExport(content);

        var assertionBuilder = await Assert.That(result).IsNotNull();
        await Assert.That(assertionBuilder!.Messages).HasMember(_ => _.Count).EqualTo(1);
        var message = (await Assert.That(assertionBuilder!.Messages).HasSingleItem())![0];
    }

    [Test]
    public async Task ParseSimpleMessage()
    {
        var content =
            """
            {
                "name": "Ринда моніторить",
                "type": "public_channel",
                "id": 1875486764,
                "messages": [
                  {
                    "id": 192,
                    "type": "message",
                    "date": "2023-05-29T04:13:27",
                    "date_unixtime": "1685315607",
                    "edited": "2023-09-12T22:29:00",
                    "edited_unixtime": "1694539740",
                    "from": "Ринда моніторить",
                    "from_id": "channel1875486764",
                    "text": "✈️БПЛА→Захід через Київщину/Житомирщину",
                    "text_entities": [
                      {
                        "type": "plain",
                        "text": "✈️БПЛА→Захід через Київщину/Житомирщину"
                      }
                    ],
                    "reactions": [
                      {
                        "type": "emoji",
                        "count": 11,
                        "emoji": "😢"
                      },
                      {
                        "type": "emoji",
                        "count": 2,
                        "emoji": "👌"
                      },
                      {
                        "type": "emoji",
                        "count": 1,
                        "emoji": "🙈"
                      }
                    ]
                  }
                ]
            }
            """;
        var result = ExportParser.ParseChatExport(content);

        var assertionBuilder = await Assert.That(result).IsNotNull();
        await Assert.That(assertionBuilder!.Messages).HasMember(_ => _.Count).EqualTo(1);
        var message = (await Assert.That(assertionBuilder!.Messages).HasSingleItem())![0];
    }

    [Test]
    public async Task ParseComplexTextMessage()
    {
        var content =
            """
            {
                "name": "Ринда моніторить",
                "type": "public_channel",
                "id": 1875486764,
                "messages": [
                  {
                    "id": 192,
                    "type": "message",
                    "date": "2023-05-29T04:13:27",
                    "date_unixtime": "1685315607",
                    "edited": "2023-09-12T22:29:00",
                    "edited_unixtime": "1694539740",
                    "from": "Ринда моніторить",
                    "from_id": "channel1875486764",
                    "text": [
                      {
                        "type": "italic",
                        "text": "❗️Загроза «Шахедів» з південного напрямку."
                      },
                      ""
                    ],
                    "text_entities": [
                      {
                        "type": "plain",
                        "text": "✈️БПЛА→Захід через Київщину/Житомирщину"
                      }
                    ],
                    "reactions": [
                      {
                        "type": "emoji",
                        "count": 11,
                        "emoji": "😢"
                      },
                      {
                        "type": "emoji",
                        "count": 2,
                        "emoji": "👌"
                      },
                      {
                        "type": "emoji",
                        "count": 1,
                        "emoji": "🙈"
                      }
                    ]
                  }
                ]
            }
            """;
        var result = ExportParser.ParseChatExport(content);

        var assertionBuilder = await Assert.That(result).IsNotNull();
        await Assert.That(assertionBuilder!.Messages).HasMember(_ => _.Count).EqualTo(1);
        var message = (await Assert.That(assertionBuilder!.Messages).HasSingleItem())![0];
    }
}
