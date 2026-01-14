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
                Summary.summarize filePath
                0
            with
                // Capture the specific exception using `as e` clause
                | :? FormatException as fe ->
                    printfn "The file was not in the expected format."
                    printfn "Details: %s" fe.Message
                    3
                | :? IOException as ioe ->
                    printfn "Could not open the file %s." filePath
                    printfn "Details: %s" ioe.Message
                    4
                | _ as ex ->
                    printfn "Unhandled exception: %s" ex.Message
                    5
        else
            printfn "Supplied file does not exist %s" filePath
            2
    else
        printfn "Please supply a filename"
        1
