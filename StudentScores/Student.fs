namespace StudentScores

type Student =
    {
        Surname: string
        GivenName: string
        Id: string
        MeanScore: float
        MaxScore: float
        MinScore: float
    }

module Student =
    
    let nameParts (s: string) =
        let elements = s.Split(',')
        let surname = elements[0].Trim()
        let givenName = elements[1].Trim()
        surname, givenName
        
    let fromString (s: string) =
        let items = s.Split('\t')
        let name = items[0]
        let surname, givenName = name |> nameParts
        let id = items[1]
        let scores =
            items
            |> Array.skip 2
            |> Array.map TestResult.fromString
            |> Array.choose TestResult.tryEffectiveScore

        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Surname = surname
            GivenName = givenName
            Id = id
            MeanScore = meanScore
            MaxScore = maxScore
            MinScore = minScore
        }

    let printSummary (student: Student) =
        printfn "%s, %s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Surname student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore

