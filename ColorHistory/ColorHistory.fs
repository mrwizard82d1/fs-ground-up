namespace ColorManagement

open System.Drawing

// Using constructor parameter of type, `seq<Color>`, provides
// flexibility to the caller of the constructor. He can provide
// any type that is compatible with or convertible to a `seq`.
type ColorHistory(initialColors: seq<Color>, maxLength: int) =
   
    let mutable colors =
        initialColors
        // Terminate the `initialColors` at `maxLength` elements
        |> Seq.truncate maxLength
        // Convert it to a List internally
        |> List.ofSeq
        
    // Access color history
    member this.Colors() =
       // Expose the internal `List` to the client as a `Seq`
       colors |> Seq.ofList
       
    // Add a color to the color history
    member this.Add(color: Color) =
        // Join `color` to `initialColors`
        // If the same `color` is already in the list, remove the
        // element added "earlier"
        // Truncate to `maxLength` elements if necessary
        // Mutate the `colors` value to contain the updated list
        let colors' =
            color::colors
            // Remember, `List.distinct` will keep the "latest" element
            // added to the list and remove the "earlier" element   
            |> List.distinct
            // Prevent the list from exceeding `maxLength`
            |> List.truncate maxLength
        colors <- colors'
        
    // Find the most recent color in the color history if any
    member this.TryLatest() =
        match colors with
        | head::_ -> head |> Some
        | [] -> None
        
    // Remove the latest element of color history
    member this.RemoveLatest() =
        let colors' =
            match colors with
            | _::tail -> tail
            | [] -> []
        colors <- colors'
        
