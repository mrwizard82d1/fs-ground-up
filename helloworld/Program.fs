// For more information see https://aka.ms/fsharp-console-apps

open System

[<EntryPoint>]
let main argv =
    printfn "Hello World from my F# program!"
    printfn "The args are: %A" argv
    0 // return an integer exit code
