[<EntryPoint>]
let main _argv =
    
    let isEven n = n % 2 = 0
    
    // Initialize an array using an expression
    let numbers = [|
        // This form yields **multiple results**
        // - 42
        // - The squares of integers 0..9 (includes 0 but not 9)
        // - 999
        42
        for i in 0..9 do
            let x = i * i
            if x |> isEven then
                x // This is the "implicit yield" form of `for...in...do`
        999
    |]

    printfn $"%A{numbers}"

    0