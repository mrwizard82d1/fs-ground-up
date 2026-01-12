namespace StudentScores

module Summary =
    open System.IO
    
    let summarize_file filePath =
        let rows = File.ReadAllLines filePath
        let studentCount = (rows |> Array.length) - 1
        printfn "Found %i students" studentCount

        rows
        // Skip first line (contains field headers)
        |> Array.skip 1
        |> Array.map Student.fromString // convert each line to a Student instance
        |> Array.sortByDescending (fun student -> student.MeanScore) // Sort by name
        |> Array.iter Student.printSummary // print the summary of each Student
