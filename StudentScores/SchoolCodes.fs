namespace StudentScores

module SchoolCodes =
    
    open System.IO
    open System.Collections.Generic

    let load (filePath: string )=
        // The value, `pairs`, refers to a sequence of .NET
        // // `KeyValuePair` items
        let pairs =
            File.ReadAllLines filePath
            |> Seq.skip 1
            |> Seq.map (fun row ->
                // Limit elements read to 2 (makes input data format
                // errors slightly more visible).
                let elements = row.Split('\t', 2)
                // Assumes the correct format (that is, can be converted
                // to an `int`)
                let id = elements.[0] |> int
                let name = elements.[1]
                // Return the `id` and `name` as a tuple
                KeyValuePair.Create(id, name))
            
        // Create a new .NET `Dictionary`
        Dictionary<int, string>(pairs)
