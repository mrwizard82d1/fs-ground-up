open System


[<EntryPoint>]
let main _argv =
    
    // Using a Sequence uses less memory than using an Array because
    // a Sequence will calculate the next item **on demand** and
    // **not** eagerly (like an Array)
    let total =
        seq { for i in 1..1000 -> i * i }
        |> Seq.sum
        
    printfn $"%d{total}"

    0