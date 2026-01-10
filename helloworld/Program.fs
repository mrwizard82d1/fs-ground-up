// For more information see https://aka.ms/fsharp-console-apps

open System

[<EntryPoint>]
let main argv =
    let person =
        if argv.Length > 0 then
            argv.[0]
        else
            "Anonymous Person"
    printfn "Hello, %s, from my F# program!" person
    0
