open System
open System.IO

[<EntryPoint>]
let main argv =
    let filePath = "Samples/StudentScores.txt"
    printfn "Data file exists? %A" (File.Exists filePath)
    0
