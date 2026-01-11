open System

let add a b =
    a + b
    
let c = add  2 3

let d = add 2

let e = d 4

[<EntryPoint>]
let main argv =
    printfn "e: %i" e
    0
