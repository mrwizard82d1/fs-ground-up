open System

module Dates =
    
    let from (startDate: DateTime) =
        Seq.initInfinite (fun i -> startDate.AddDays(float i))

[<EntryPoint>]
let main _argv = 

    Dates.from DateTime.Now
    |> Seq.filter (fun d -> d.Month = 1 && d.Day = 1)
    |> Seq.iter (fun d -> printfn $"%i{d.Year} %s{d.DayOfWeek.ToString()}")

    0