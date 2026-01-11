open System
open System.IO

type Student =
    {
        Name: string
        Id: string
        MeanScore: float
        MaxScore: float
        MinScore: float
    }

module Student =
    let fromString (s: string) =
        let items = s.Split('\t')
        let name = items[0]
        let id = items[1]
        let scores =
            items
            |> Array.skip 2
            |> Array.map float
        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Name = name
            Id = id
            MeanScore = meanScore
            MaxScore = maxScore
            MinScore = minScore
        }

    let printSummary (student: Student) =
        printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Name student.Id student.MeanScore student.MinScore student.MaxScore

let summarize_file filePath =
    let rows = File.ReadAllLines filePath
    let studentCount = (rows |> Array.length) - 1
    printfn "Found %i students" studentCount

    rows
    // Skip first line (contains field headers)
    |> Array.skip 1
    |> Array.map Student.fromString // convert each line to a Student instance
    |> Array.sortBy (fun student -> student.Name) // Sort by name
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
