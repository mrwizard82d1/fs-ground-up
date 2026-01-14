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
        let rows = File.ReadAllLines filePath
        let studentCount = (rows |> Array.length) - 1
        printfn "Found %i students" studentCount

        rows
        // Skip first line (contains field headers)
        |> Array.skip 1
        |> Array.map Student.fromString // convert each line to a Student instance
        // Group students by surname
        |> Array.groupBy (fun student -> student.Surname)
        // Sort students with same surname by given name
        |> Array.sortBy fst
        // Print the summary of each student in the group
        |> Array.iter (fun (surname, students) ->
            printGroupSummary surname students)
