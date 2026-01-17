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
    
    // Set the console foreground and background, but allow the user
    // to change it later.
    let mutable foreground = ConsoleColor.White
    let mutable background = ConsoleColor.Black
    
    // Member definitions
    
    // Get "console color scheme"
    member this.ColorScheme
        with get() =
            foreground, background
        and set(fg, bg  ) =
            if fg = bg then
                raise <| ArgumentException("The foreground and background colors cannot be the same.")
            foreground <- fg
            background <- bg
    
    // Defining a member using `this.` In addition, within a member,
    // one can access members defined in the constructor **without**
    // a reference to `this`.
    member this.GetValue() =
        tryCount <- tryCount + 1
        
        Console.ForegroundColor <- foreground
        Console.BackgroundColor <- background
            
        printf $"%s{trimmedMessage}: "
        Console.ResetColor()
        
        let input = Console.ReadLine()
        
        // Check for no input. If so, try again.
        if String.IsNullOrWhiteSpace(input) && tryCount < maxTries then
            if this.BeepOnError then
                Console.Beep()
            this.GetValue()
        else
            input
            
    // Set flag to true to beep when an error occurs
    //
    // This simple implementation works fine for simple behavior;
    // however, what if we want more complex behavior? (See behavior
    // around `foreground` and `background`.)
    member val BeepOnError = true
        // This member can be both read and written after construction
        with get, set
