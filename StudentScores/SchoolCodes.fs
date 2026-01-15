namespace StudentScores

module SchoolCodes =
    
    open System.IO
    open System.Collections.Generic

    let load (filePath: string )=
        // // The value, `pairs`, refers to a sequence of .NET
        // // // `KeyValuePair` items
        // let pairs =
        //     File.ReadAllLines filePath
        //     |> Seq.skip 1
        //     |> Seq.map (fun row ->
        //         // Limit elements read to 2 (makes input data format
        //         // errors slightly more visible).
        //         let elements = row.Split('\t', 2)
        //         // Assumes the correct format (that is, can be converted
        //         // to an `int`)
        //         let id = elements.[0] |> int
        //         let name = elements.[1]
        //         // Return the `id` and `name` as a tuple
        //         KeyValuePair.Create(id, name))
        //     
        // // Create a new .NET `Dictionary`
        // //
        // // The F# compiler can (often) infer the correct types to put
        // // in the dictionary.
        //
        // Use similar code to create a .NET `Dictionary` if you want to
        // **mutate** the dictionary later. Using `dict` provided by F#
        // language creates an **immutable** `Dictionary`.
        // Dictionary<_, _>(pairs)
        
        File.ReadAllLines filePath
        |> Seq.skip 1
        |> Seq.map (fun row ->
            let elements = row.Split('\t', 2)
            let id = elements.[0] |> int
            let name = elements.[1]
            id, name)
        // This expression pipes the pairs into the `dict` function
        // which can be used to create .NET `IDictionary`. Note that
        // the function, `dict`, creates a `Dictionary` (that
        // implements `IDictionary`)
        |> dict
