open System


[<EntryPoint>]
let main _argv =
    
    // Other ways to initialize Arrays
    let numbers = Array.init 5 (fun i -> pown 2 i)

    printfn $"%A{numbers}"
    
    let total =
        Array.init 1000 (fun i -> (i + 1) * (i * 1))
        |> Array.sum
        
    printfn $"%d{total}"

    0