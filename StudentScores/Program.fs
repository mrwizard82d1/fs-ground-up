open System
open System.IO

let printMeanScore (row: string) =
    let items = row.Split('\t')
    let name = items[0]
    let id = items[1]
    let scores =
        items
        |> Array.skip 2


    printfn "%s %s %A" name id scores

let summarize_file filePath =
    let rows = File.ReadAllLines filePath
    let studentCount = (rows |> Array.length) - 1
    printfn "Found %i students" studentCount

    rows
    // Skip first line (contains field headers)
    |> Array.skip 1
    |> Array.iter printMeanScore


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
