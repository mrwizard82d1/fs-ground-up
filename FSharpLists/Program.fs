open System

[<EntryPoint>]
let main _argv =
    // The literal for a List is just like the literal for an Array
    // but without the vertical bars
    let numbers = [1; 2; 4; 8; 16]
    printfn $"A literal list:\n%A{numbers}"
    
    let moreNumbers = [
        for i in 0..4 -> pown 2 i
    ]
    printfn $"A list initialized using `for..in`\n%A{moreNumbers}"
    
    // Note that Rider recommended using the partial
    // function, `(pown 2)`
    let yetMoreNumbers = List.init 5 (pown 2)
    printfn $"Using `List.init`\n%A{yetMoreNumbers}"
    
    let total =
        [ for i in 1..1000 -> i * i ]
        |> List.sum
    printfn $"We can sum the items in a `List` using `List.sum\n%d{total}"
    
    let thirdNumber = yetMoreNumbers[2]
    printfn $"Access items in list using indices (but be aware of performance)\n%d{thirdNumber}"
    
    // But you **cannot** modify items in a List (unlike an Array).
    // (Uncomment this line to see the compiler complain.)
    // yetMoreNumbers[1] <- 99
    
    let strings = [ "the"; "cat"; "sat" ]
    printfn $"Strings in a list:\n%A{strings}"
    
    // Use the "cons" operator, `::` to add an item to the
    // (head of) the list
    let strings2 = "sometimes" :: strings
    printfn $"After adding an element:\n%A{strings2}"
    
    // We can also "split" a list into its "head" (the first element)
    // and its "tail" (the list of all the elements **except** the
    // first element) using a `match` expression.
    match strings2 with
    | head::tail ->
        printfn $"Head: \"%s{head}\", tail: %A{tail}"
    | [] -> // The empty list
        printfn "Empty list"
    
    // Silly, I know
    match [] with
    | head::tail ->
        printfn $"Head: \"%s{head}\", tail: %A{tail}"
    // The empty list. We could use `_` but `[]` makes our intent clear
    | [] ->
        printfn "(Silly, I know.) Empty list"
    
    0