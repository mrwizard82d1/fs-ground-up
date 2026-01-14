open System


[<EntryPoint>]
let main _argv =
    
    // Other ways to initialize Arrays
    let numbers = Array.init 5 (fun i -> pown 2 i)

    printfn $"%A{numbers}"

    0