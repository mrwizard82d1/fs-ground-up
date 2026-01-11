namespace StudentScores

module Float =
    // Try to convert a string to a floating point number
    let tryFromString s =
        if s = "N/A" then
            None
        else
            Some (float s)
   
    let tryFromStringOr d s =
        s
        |> tryFromString
        |> Option.defaultValue d
