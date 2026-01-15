open System

module MathSequence =
    
    type State = {
        n: int
        pSub1: int
        pSub2: int
    }
    
    let pell =
        let initialState = { n = 0; pSub1 = 0; pSub2 = 0 }
        initialState
        |> Seq.unfold (fun state ->
            // Calculate the next item in the sequence
            let pSubN =
                match state.n with
                | 0 | 1 ->
                    state.n
                | _ ->
                    2 * state.pSub1 + state.pSub2
            // Increment the index of the sequence item 
            let n' = state.n + 1
            // Return the next item in the sequence (`pn` or p-sub-n)
            // and a tuple consisting of
            // - The index of the next item in the sequence
            // - The previous item in the sequence
            // - The (calculated) next item in the sequence
            //
            // Interesting... Somehow in my solution, I did not realize
            // that the first item in original tuple was modeling
            // p-sub-n-minus-2 and the second item was modeling
            // p-sub-n-minus-1.
            Some (pSubN, { n = n'; pSub2 = state.pSub1; pSub1 = pSubN }))

[<EntryPoint>]
let main _argv = 

    MathSequence.pell
    |> Seq.truncate 10
    |> Seq.iter (fun x -> printf $"%A{x}, ")
    
    printfn "..."
    
    0
