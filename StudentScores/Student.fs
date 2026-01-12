namespace StudentScores

type Student =
    {
        Name: string
        Id: string
        MeanScore: float
        MaxScore: float
        MinScore: float
    }

module Student =
    let fromString (s: string) =
        let items = s.Split('\t')
        let name = items[0]
        let id = items[1]
        let scores =
            items
            |> Array.skip 2
            |> Array.map (Float.tryFromStringOr 50.0)
        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Name = name
            Id = id
            MeanScore = meanScore
            MaxScore = maxScore
            MinScore = minScore
        }

    let printSummary (student: Student) =
        printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Name student.Id student.MeanScore student.MinScore student.MaxScore

