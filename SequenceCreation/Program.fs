open System

[<EntryPoint>]
let main _argv = 

    let total =
        // seq { for i in 1..1000 -> i * i }
        //
        // Illustrate initializing a sequence (like `Array.init`)
        Seq.init 1000 (fun i ->
            let j = i + 1
            j * j)
        |> Seq.sum

    printfn $"The total is: %i{total}"

    0