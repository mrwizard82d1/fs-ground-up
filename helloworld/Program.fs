// For more information see https://aka.ms/fsharp-console-apps

open System

[<EntryPoint>]
let main argv =
    let person = argv.[0] // Get first item in argv
    printfn "Hello, %s, from my F# program!" person
    0 // return an integer exit code
