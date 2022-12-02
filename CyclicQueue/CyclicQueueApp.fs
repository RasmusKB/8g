open CyclicQueue

let createTest () : bool =
    create 5
    let _ = enqueue 0
    create 3
    if queue.Length = 3 && queue[0].IsNone then
        true
    else
        false

let enqueueTest () : bool =
    create 3
    let _ = enqueue 5
    let _ = enqueue 5
    let _ = enqueue 5
    if queue[0].IsSome && (enqueue 0) = false then
        true
    else
        false

let dequeueTest () : bool =
    create 3
    let _ = enqueue 4
    let elm = queue[0]
    if elm = dequeue() then
        true
    else
        false

let emptyTest () : bool =
    create 5
    if isEmpty() = true then
        true
    else
        false

let lengthTest () : bool =
    create 5
    let _ = enqueue 4
    let _ = enqueue 4
    if (length()) = 2 then
        true
    else
        false

let stringTest () : bool =
    create 2
    if (toString () = "0: None 1: None ") then
        true
    else
        false
[<EntryPoint>]
let main _ =
    let mutable exitstatus = 0
    if createTest () = false then
        exitstatus <- exitstatus + 1
        printfn"'create' creates and clears queue: %A" false
    else
        printfn"'create' creates and clears queue: %A" true

    if enqueueTest () = false then
        exitstatus <- exitstatus + 1
        printfn"'enqueue' enqueues element and returns false when queue is full: %A" false
    else
        printfn"'enqueue' enqueues element and returns false when queue is full: %A" true

    if dequeueTest () = false then
        exitstatus <- exitstatus + 1
        printfn"'dequeue' returns first element of queue: %A" false
    else
        printfn"'dequeue' returns first element of queue: %A" true

    if emptyTest () = false then
        exitstatus <- exitstatus + 1
        printfn"'isEmpty' returns true if queue is empty: %A" false
    else
        printfn"'isEmpty' returns true if queue is empty: %A" true

    if lengthTest () = false then
        exitstatus <- exitstatus + 1
        printfn"'length' returns length of queue: %A" false
    else
        printfn"'length' returns length of queue: %A" true

    if stringTest () = false then
        exitstatus <- exitstatus + 1
        printfn"'toString' returns the queue as a string: %A" false
    else
        printfn"'toString' returns the queue as a string: %A" true

    printfn"Number of failed tests: %A" exitstatus
    exitstatus
