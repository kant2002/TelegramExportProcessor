using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TelegramExportProcessor;

[JsonConverter(typeof(ComplextTextJsonConverter))]
public class ComplextText
{
    public List<TextEntity> Parts { get; } = new List<TextEntity>();
}
