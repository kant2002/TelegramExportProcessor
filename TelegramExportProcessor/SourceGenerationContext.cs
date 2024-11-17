// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;

[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.KebabCaseLower)]
[JsonSerializable(typeof(ChatExport))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
