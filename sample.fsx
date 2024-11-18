#r "nuget: TelegramExportProcessor, 0.0.3"

open System
open TelegramExportProcessor

let args = fsi.CommandLineArgs

let find_string (messages: ChatMessage seq) (searchString : string) =
    messages |> Seq.filter (fun m -> m.TextEntities |> Seq.exists(fun te -> te.Text.Contains(searchString)))

let print_messages (messages: string seq) =
    for m in messages do
        printfn "%s\n======================================" m

let format_message (message : ChatMessage) =
    let messageParts = message.TextEntities |> Seq.map (fun te -> te.Text)
    ("", messageParts) |> System.String.Join

let search_in_file file searhString =
    let data = ExportParser.ParseChatExportFile file
    let messages_with_string = find_string data.Messages searhString |> Seq.map format_message
    print_messages messages_with_string

match args with
| [| _ ; _ |] -> raise (Exception "Please specify search string")
| [| _ ; file; searchString |] -> search_in_file file searchString
| [| _; _ ; _  ; _|] -> raise (Exception "Too many parameters given")
| _ -> raise (Exception "No export file given")
