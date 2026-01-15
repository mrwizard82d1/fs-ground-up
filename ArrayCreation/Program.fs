open System


[<EntryPoint>]
let main _argv =
    
    // Other ways to initialize Arrays
    let initiallyZeros = Array.zeroCreate<int> 10
    
    // NOTE: items of type `Array` are **mutable** by default
    initiallyZeros.[0] <- 42

    printfn $"%A{initiallyZeros}"

    0