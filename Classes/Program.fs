open Classes

[<EntryPoint>]
let main _argv =
    // Invoking the `ConsolePrompt` constructor using `new`
    // is **optional**. Note that instantiating this class
    // **does not** actually prompt the user. The user is actually
    // prompted to enter data when the `GetValue()` method is invoked.
    let namePrompt = ConsolePrompt("Please enter your name:")
    
    // Invokes the instance method, `GetValue()`. This method actually
    // prompts the user for her name.
    let name = namePrompt.GetValue()
    
    printfn $"Hello %s{name}"
    
    0
