open System.IO

open StudentScores

[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filePath = argv.[0]
        if File.Exists filePath then
            printfn "Processing %s" filePath
            Summary.summarize_file filePath
            0
        else
            printfn "Supplied file does not exist %s" filePath
            2
    else
        printfn "Please supply a filename"
        1
