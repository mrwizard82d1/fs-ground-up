open System
open Classes

[<EntryPoint>]
let main _argv =
    let namePrompt = ConsolePrompt("Please enter your name", 3)
    let name = namePrompt.GetValue()
    
    printfn $"Hello %s{name}"
    
    let colorPrompt = ConsolePrompt("What is your favorite color (press `Enter` if you don't have one", 1)
    let favoriteColor = colorPrompt.GetValue()
    
    let person = Person(name, favoriteColor)
    printfn $"%s{person.Description()}"
    
    0
