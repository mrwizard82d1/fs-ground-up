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
    
    0
