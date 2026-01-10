// For more information see https://aka.ms/fsharp-console-apps

open System

let greet person =
   printfn "Hello, %s, from my F# program!" person

[<EntryPoint>]
let main argv =
    Array.iter greet argv
    printfn "Nice to meet you."
    0
