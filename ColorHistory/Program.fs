open System
open System.Drawing
open ColorManagement

let listColors (history: ColorHistory) =
    
    history.Colors()
    |> Seq.iter (printf "%A ")
    printfn ""
    
[<EntryPoint>]
let main _argv =
    
    printfn "I can create a color history with some colors: "
    let history = ColorHistory([ Color.Indigo; Color.Violet ], 7)
    history |> listColors
    
    printfn "I can add a color:"
    history.Add(Color.Blue)
    history |> listColors
    printfn "The new color is the latest:"
    printfn $"%O{history.TryLatest()}"
    
    printfn "After adding an existing color:"
    history.Add(Color.Violet)
    history |> listColors
    printfn "The newly added color is the latest and the original is removed."
    printfn $"%O{history.TryLatest()}"
    
    0
