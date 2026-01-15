open System
open System.IO

open StudentScores

[<EntryPoint>]
let main argv =
    if argv.Length = 2 then
        let schoolCodesFilePath = argv.[0]
        let studentsFilePath = argv.[1]
        
        if not (File.Exists schoolCodesFilePath) then
            printfn $"File not found: %s{schoolCodesFilePath}"
            1
        elif not (File.Exists studentsFilePath) then
            printfn $"Supplied file does not exist %s{studentsFilePath}"
            2
        else
            printfn $"Processing %s{studentsFilePath}"
            try
                Summary.summarize schoolCodesFilePath studentsFilePath
                0
            with
                // Capture the specific exception using `as e` clause
                | :? FormatException as fe ->
                    printfn "The file was not in the expected format."
                    printfn $"Details: %s{fe.Message}"
                    3
                | :? IOException as ioe ->
                    printfn $"Could not open the file %s{studentsFilePath}."
                    printfn $"Details: %s{ioe.Message}"
                    4
                | _ as ex ->
                    printfn $"Unhandled exception: %s{ex.Message}"
                    5
    else
        printfn "Please supply a school codes pathname and a student test scores pathname"
        6
