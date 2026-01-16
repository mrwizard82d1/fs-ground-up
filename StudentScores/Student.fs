namespace StudentScores

type Student =
    {
        Surname: string
        GivenName: string
        Id: string
        SchoolName: string
        MeanScore: float
        MaxScore: float
        MinScore: float
    }

module Student =
    
    open System.Collections.Generic
    
    let nameParts (s: string) =
        let elements = s.Split(',')
        match elements with
            | [| surname; givenName |] ->
                {|
                   Surname = surname.Trim()
                   GivenName = givenName.Trim()
                |}
            | [| surname |] ->
                {|
                   Surname = surname.Trim()
                   GivenName = "(None)"
                |}
            | _ ->
                raise (System.FormatException(sprintf "Invalid name format: \"%s\"" s))
                
    let fromString (schoolCodes: IDictionary<int, string>) (s: string) =
        let items = s.Split('\t')
        let name = items[0] |> nameParts
        let id = items[1]
        let schoolCode = items.[2] |> int
        let schoolName =
            match schoolCodes.TryGetValue schoolCode with
            | true, name -> name
            | false, _ -> "(Unknown)"
        let scores =
            items
            |> Array.skip 3
            |> Array.map TestResult.fromString
            |> Array.choose TestResult.tryEffectiveScore

        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Surname = name.Surname
            GivenName = name.GivenName
            Id = id
            SchoolName = schoolName
            MeanScore = meanScore
            MaxScore = maxScore
            MinScore = minScore
        }

    let printSummary (student: Student) =
        printfn "%s, %s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f"
            student.Surname student.GivenName student.Id student.SchoolName
            student.MeanScore student.MinScore student.MaxScore
