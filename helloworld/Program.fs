// For more information see https://aka.ms/fsharp-console-apps

open System

let greet person =
    printfn "Hello, %s, from my F# program!" person

let isValid person =
    // A person (name) is valid if it **does not** consist solely
    // of whitespace
    not(String.IsNullOrWhiteSpace person)

[<EntryPoint>]
let main argv =
    let validNames = argv |> Array.filter isValid
    validNames |> Array.iter greet

    printfn "Nice to meet you."
    0
