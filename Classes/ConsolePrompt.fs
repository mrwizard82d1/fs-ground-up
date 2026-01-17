namespace Classes

open System

type ConsolePrompt(message: String, maxTries: int) =
    // Constructor (through `let trimmedMessage = ...`)
    do
        if String.IsNullOrWhiteSpace(message) then
            // The following line is equivalent to `raise(ArgumentException(...))`
            // Usage: makes the raising of the exception a tad more "obvious"
            raise <| ArgumentException("Null or empty", "message")
    let trimmedMessage = message.Trim()
    
    // Limit number of invalid input attempts
    let mutable tryCount = 0
    
    // Member definitions
    
    // Defining a member using `this.` In addition, within a member,
    // one can access members defined in the constructor **without**
    // a reference to `this`.
    member this.GetValue() =
        tryCount <- tryCount + 1
        printf $"%s{trimmedMessage}: "
        let input = Console.ReadLine()
        
        // Check for no input. If so, try again.
        if String.IsNullOrWhiteSpace(input) && tryCount < maxTries then
            this.GetValue()
        else
            input
