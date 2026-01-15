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
        // This implementation contains a "major" mistake: it reads the
        // sequence of lines in the file **twice**: once when calculating
        // the `studentCount` (calling `Seq.length`) and once when
        // iterating over the sequence to print the summary for
        // each `Student`.
        //
        // To repair this issue, I cache the sequence I read from disk.
        // This action retains the sequence after it is read (at the
        // cost of core memory) but prevents us from needing to read
        // the data from the disk again (a **very** slow operation).
        //
        // In general, because the data read is so small, one may
        // not notice the difference when executing this example
        // program because the data is relatively small. (Although,
        // I thought I noticed a slight difference in running this
        // version of the code compared to the implementation without
        // caching the lines read from disk.
        let rows =
            File.ReadLines filePath
            |> Seq.cache
        let studentCount = (rows |> Seq.length) - 1
        printfn "Found %i students" studentCount

        rows
        |> Seq.skip 1
        |> Seq.map Student.fromString
        |> Seq.sortByDescending (fun student -> student.MeanScore)
        |> Seq.iter Student.printSummary
