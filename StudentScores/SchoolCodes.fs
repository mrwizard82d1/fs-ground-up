namespace StudentScores

module SchoolCodes =
    
    open System.IO
    open System.Collections.Generic

    let load (filePath: string )=
        // // The value, `pairs`, refers to a sequence of .NET
        // // // `KeyValuePair` items
        File.ReadAllLines filePath
        |> Seq.skip 1
        |> Seq.map (fun row ->
            let elements = row.Split('\t', 2)
            let id = elements[0] |> int
            let name = elements[1]
            id, name)
        // This expression pipes the pairs into the `dict` function
        // which can be used to create .NET `IDictionary`. Note that
        // the function, `dict`, creates a `Dictionary` (that
        // implements `IDictionary`)
        |> Map.ofSeq
        // To support a "homeschooled" student, we add a "special" item
        // with the key 0 (an `int`)
        |> Map.add 0 "(External)"
