open System

[<EntryPoint>]
let main _argv = 

    let squares =
        Seq.initInfinite (fun i ->
            let j = i + 1
            j * j)
    let total =
        squares
        // Hmm... Why not `Seq.take`?
        |> Seq.truncate 1000
        |> Seq.sum

    printfn $"The total is: %i{total}"

    0