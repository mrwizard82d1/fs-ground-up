open System

[<EntryPoint>]
let main _argv =
    
    // Initialize an array using an expression
    let numbers = [|
        for i in 0..4 -> pown 2 i
    |]

    printfn $"%A{numbers}"

    0