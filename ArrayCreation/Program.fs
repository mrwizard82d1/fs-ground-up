open System


[<EntryPoint>]
let main _argv =
    
    let isEven n = n % 2 = 0
    
    let todayIsThursday() =
        DateTime.Now.DayOfWeek = DayOfWeek.Thursday
    
    // Initialize an array using an "Array comprehension"
    let numbers = [|
        // This form yields **multiple results**
        // - 42 (if today is Thursday)
        // - The squares of integers 0..9 (includes 0 but not 9)
        // - 999
        if todayIsThursday () then 42
        // if not (todayIsThursday ()) then 42
        for i in 0..9 do
            let x = i * i
            if x |> isEven then
                x // This is the "implicit yield" form of `for...in...do`
        999
    |]

    printfn $"%A{numbers}"
    
    // Calculate the sum of the squares of integers between
    // 1 and 1000, inclusive.
    let squares_1_1000 = [|
        for i in 1..1000 -> i * i
    |]
    
    let result = Array.sum(squares_1_1000)
    
    printfn $"%d{result}"

    0