module CyclicQueue
//123
type Value = int

let mutable first = None

let mutable last = None

let mutable queue : Value option[] = [||]

let create (n: int) : unit =
    queue <- Array.create n None
    ()

let enqueue (e: Value) : bool =
    if last.IsNone then
        queue[0] <- Some e
        last <- Some 0
        first <- Some 0
        true
    elif ((last.IsSome) && (first.IsSome)) then
        if (((last|>Option.get)+1) % queue.Length) = (first|>Option.get) then
            false
        elif (last|>Option.get) = (queue.Length - 1) then
            last <- Some ((last|>Option.get) % (queue.Length - 1))
            queue[(last|>Option.get)] <- Some e
            true
        else
            last <- Some ((last|>Option.get) + 1)
            queue[(last|>Option.get)] <- Some e
            true
    else
        false

let dequeue () : Value option =
    if first.IsNone then
        None
    elif ((first|>Option.get) = (last|>Option.get)) then
        let res1 = queue[(first|>Option.get)]
        first <- None
        last <- None
        res1
    elif (first|>Option.get) = (queue.Length - 1) then
        let res2 = queue[(first|>Option.get)]
        first <- Some ((first|>Option.get) % (queue.Length - 1))
        res2
    else
        let res3 = queue[(first|>Option.get)]
        first <- Some ((first|>Option.get) + 1)
        res3

let isEmpty () : bool =
    let mutable count = 0
    for i = 0 to ((queue.Length)-1) do
        if ((last.IsSome) || (first.IsSome)) then
            ()
        else
            count <- count + 1
    if count = (queue.Length) then
        true
    else
        false


let length () : int =
    let mutable count = 0
    for i = 0 to ((queue.Length)-1) do
        if queue[i].IsSome then
            count <- count + 1
        else
            ()
    count

let toString () : string =
    let mutable streng = ""
    for i = 0 to ((queue.Length)-1) do
        if queue[i].IsNone then
            streng <- streng + string(i) + ": " + "None" + " "
        else
            streng <- streng + string(i) + ": " + string(queue[i]|>Option.get) + " "
    streng
