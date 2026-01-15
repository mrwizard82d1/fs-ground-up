open System

module MathSequence =
    
    let pell =
        // (index of the sequence item to calculate;
        //  p-sub-n-minus-1; p-sub-n-minus-2)
        (0, 0, 0)
        |> Seq.unfold (fun (n, pn2, pn1) ->
            // Calculate the next item in the sequence
            let pn =
                match n with
                | 0 | 1 ->
                    n
                | _ ->
                    2 * pn1 + pn2
            // Increment the index of the sequence item 
            let n' = n + 1
            // Return the next item in the sequence (`pn` or p-sub-n)
            // and a tuple consisting of
            // - The index of the next item in the sequence
            // - The previous item in the sequence
            // - The (calculated) next item in the sequence
            Some (pn, (n', pn1, pn)))

[<EntryPoint>]
let main _argv = 

    MathSequence.pell
    |> Seq.truncate 10
    |> Seq.iter (fun x -> printf $"%i{x}, ")
    
    printfn "..."
    
    0
