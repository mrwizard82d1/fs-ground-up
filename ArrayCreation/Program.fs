open System


[<EntryPoint>]
let main _argv =
    
    // Other ways to initialize Arrays
    let initiallyZeros = Array.zeroCreate<int> 10

    printfn $"%A{initiallyZeros}"

    0