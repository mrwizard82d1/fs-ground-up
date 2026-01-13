open System
open System.IO

open StudentScores

[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filePath = argv.[0]
        if File.Exists filePath then
            printfn "Processing %s" filePath
            try
                Summary.summarize_file filePath
                0
            with
                // Capture the specific exception using `as e` clause
                | :? FormatException as e ->
                    printfn "The file was not in the expected format."
                    printfn "Details: %s" e.Message
                    1
        else
            printfn "Supplied file does not exist %s" filePath
            2
    else
        printfn "Please supply a filename"
        3
