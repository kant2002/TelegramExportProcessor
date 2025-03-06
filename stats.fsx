#r "nuget: TelegramExportProcessor, 0.0.3"

open System
open TelegramExportProcessor

let args = fsi.CommandLineArgs

let search_in_file file =
    let data = ExportParser.ParseChatExportFile file
    printfn "Entry types:"
    let entity_types = data.Messages |> Seq.collect (fun x -> x.TextEntities |> Seq.map (fun te -> te.Type)) |> Seq.distinct |> Seq.sort
    for etype in entity_types do
        printfn "%s" etype
    printfn "Message types:"
    let message_types = data.Messages |> Seq.map (fun x -> x.Type) |> Seq.distinct |> Seq.sort
    for mtype in message_types do
        printfn "%s" mtype
    printfn "Reaction types:"
    let reaction_types =
        data.Messages
        |> Seq.filter (fun rt -> isNull rt.Reactions |> not)
        |> Seq.collect (fun x -> x.Reactions |> Seq.map (fun r -> r.Type))
        |> Seq.distinct
        |> Seq.sort
    for rtype in reaction_types do
        printfn "%s" rtype

match args with
| [| _ ; file |] -> search_in_file file
| [| _; _ ; _ |] -> raise (Exception "Too many parameters given")
| _ -> raise (Exception "No export file given")
