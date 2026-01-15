namespace StudentScores

module Summary =
    open System.IO
    
    let printGroupSummary (surname: string) (students: Student[]) =
        printfn "%s" (surname.ToUpperInvariant())
        
        students
        // Correct minor error for students with same name (given and surname)
        |> Array.sortBy (fun student -> student.GivenName, student.Id)
        |> Array.iter (fun student ->
            printfn "\t%20s\t%s\t%0.1f\t%0.1f\t%0.1f"
                student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore)
    
    let summarize filePath =
        let rows = File.ReadLines filePath
        let studentCount = (rows |> Seq.length) - 1
        printfn "Found %i students" studentCount

        rows
        |> Seq.skip 1
        |> Seq.map Student.fromString
        |> Seq.sortByDescending (fun student -> student.MeanScore)
        |> Seq.iter Student.printSummary
