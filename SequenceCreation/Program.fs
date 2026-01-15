open System

module Drunkard =
    
    let r = System.Random() // A random number generator
    
    // Returns a random integer between -1 and +1, inclusive.
    let step() =
        r.Next(-1, 2)
        
    type Position = {
        X: int
        Y: int
    }
    
    let walk =
        { X = 0; Y = 0 }
        |> Seq.unfold (fun position ->
            let x' = position.X + step()
            let y' = position.Y + step()
            let position' = { X = x'; Y = y' }
            Some(position', position'))

[<EntryPoint>]
let main _argv = 

    printf "Drunkard's walk"
    
    Drunkard.walk
    |> Seq.take 10
    |> Seq.iter (fun p -> printfn $"X: %i{p.X} Y: %i{p.Y}")
    
    0
