namespace Classes

open System

type ConsolePrompt(message: String) =
    // Constructor (through `let trimmedMessage = ...`)
    do
        if String.IsNullOrWhiteSpace(message) then
            // The following line is equivalent to `raise(ArgumentException(...))`
            // Usage: makes the raising of the exception a tad more "obvious"
            raise <| ArgumentException("Null or empty", "message")
    let trimmedMessage = message.Trim()
    
    // Member definitions
    
    // Defining a member using `this.` In addition, within a member,
    // one can access members defined in the constructor **without**
    // a reference to `this`.
    member this.GetValue() =
        printf $"%s{trimmedMessage}"
        let input = Console.ReadLine()
        input
