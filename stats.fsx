#r "nuget: TelegramExportProcessor, 0.0.4"

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

    let printMessagesPerDay (data: ChatExport) =
        printfn "Messages per day from channel %s:" data.Name
        let messages_per_day =
            data.Messages
            |> Seq.groupBy (fun rt -> rt.Date.Date)
            |> Seq.map (fun (date, messages) -> (date, messages |> Seq.length))
        for (date, messages_qty) in messages_per_day do
            printfn "%s - %d" (date.ToShortDateString()) messages_qty

    let printMessagesPerWeek (data: ChatExport) =
        printfn "Messages per week from channel %s:" data.Name
        let messages_per_day =
            data.Messages
            |> Seq.groupBy (fun rt -> (rt.Date.Year, rt.Date.DayOfYear / 7))
            |> Seq.map (fun (week, messages) -> (week, messages |> Seq.length))
        for ((year, week), messages_qty) in messages_per_day do
            printfn "%d - Week %d - %d" year week messages_qty

    let printUsersPerWeek (data: ChatExport) =
        printfn "Users per week from channel %s:" data.Name
        let messages_per_day =
            data.Messages
            |> Seq.groupBy (fun rt -> (rt.Date.Year, rt.Date.DayOfYear / 7))
            |> Seq.map (fun (week, messages) -> (week, messages |> Seq.countBy (fun m -> m.FromId) |> Seq.length))
        for ((year, week), messages_qty) in messages_per_day do
            printfn "%d - Week %d - %d" year (week + 1) messages_qty

    let printUsersPerMonth (data: ChatExport) =
        printfn "Users per month from channel %s:" data.Name
        printfn ""
        let messages_per_day =
            data.Messages
            |> Seq.groupBy (fun rt -> (rt.Date.Year, rt.Date.Month))
            |> Seq.map (fun (week, messages) -> (week, messages |> Seq.countBy (fun m -> m.FromId) |> Seq.length))
        for ((year, month), messages_qty) in messages_per_day do
            printfn "%d - Month %d - %d" year (month + 1) messages_qty

    let printUsersPerDay (data: ChatExport) =
        printfn "Users per day from channel %s:" data.Name
        printfn ""
        let messages_per_day =
            data.Messages
            |> Seq.groupBy (fun rt -> (rt.Date.Year, rt.Date.DayOfYear))
            |> Seq.map (fun (week, messages) -> (week, messages |> Seq.countBy (fun m -> m.FromId) |> Seq.length))
        for ((year, week), messages_qty) in messages_per_day do
            printfn "%d - Day %d - %d" year (week + 1) messages_qty

    let printUsersPerDate (data: ChatExport) =
        printfn "Users per date from channel %s:" data.Name
        printfn ""
        let messages_per_day =
            data.Messages
            |> Seq.groupBy (fun rt -> rt.Date.Date)
            |> Seq.map (fun (week, messages) -> (week, messages |> Seq.countBy (fun m -> m.FromId) |> Seq.length))
        for (date, messages_qty) in messages_per_day do
            printfn "%s - %d" (date.ToShortDateString()) messages_qty
    //printUsersPerDay data
    //printUsersPerDate data
    //printUsersPerMonth data
    //printUsersPerWeek data
    printMessagesPerWeek data
    //printMessagesPerDay data


match args with
| [| _ ; file |] -> search_in_file file
| [| _; _ ; _ |] -> raise (Exception "Too many parameters given")
| _ -> raise (Exception "No export file given")
