// For more information see https://aka.ms/fsharp-console-apps

open System

[<EntryPoint>]
let main argv =
    let mutable person = "Anonymous Person"
    if argv.Length > 0 then
        person <- argv.[0]
    printfn "Hello, %s, from my F# program!" person
    0
