namespace StudentScores

module Float =
    // Try to convert a string to a floating point number
    let tryFromString s =
        if s = "N/A" then
            Nothing
        else
            Something (float s)
   
    let fromStringOr d s =
        s
        |> tryFromString
        |> Optional.defaultValue d
