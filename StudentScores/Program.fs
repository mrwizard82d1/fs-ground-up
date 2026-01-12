open System
open System.IO

open StudentScores

let summarize_file filePath =
    let rows = File.ReadAllLines filePath
    let studentCount = (rows |> Array.length) - 1
    printfn "Found %i students" studentCount

    rows
    // Skip first line (contains field headers)
    |> Array.skip 1
    |> Array.map Student.fromString // convert each line to a Student instance
    |> Array.sortByDescending (fun student -> student.MeanScore) // Sort by name
    |> Array.iter Student.printSummary // print the summary of each Student

[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filePath = argv.[0]
        if File.Exists filePath then
            printfn "Processing %s" filePath
            summarize_file filePath
            0
        else
            printfn "Supplied file does not exist %s" filePath
            2
    else
        printfn "Please supply a filename"
        1
