namespace StudentScores

type Optional<'T> =
    | Something of 'T
    | Nothing

module Demo =
    
    let a = Something "abc"
    let b = Something 7
    let c = Something 3.14
    let d = Nothing
