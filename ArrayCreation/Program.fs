[<EntryPoint>]
let main _argv =
    
    let isEven n = n % 2 = 0
    
    // Initialize an array using an expression
    let numbers = [|
        for i in 0..9 do
            let x = i * i
            if x |> isEven then
                x // This is the "implicit yield" form of `for...in...do`
    |]

    printfn $"%A{numbers}"

    0