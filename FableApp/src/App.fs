module App

open Browser.Dom

let myButton = document.querySelector(".my-button") :?> Browser.Types.HTMLButtonElement

let countAttrName = "data-count"

myButton.setAttribute(countAttrName, string 0)



let setCount cnt =
        myButton.setAttribute(countAttrName, string cnt)
        myButton.innerText <- sprintf "You clicked: %i time(s)" cnt
    
myButton.onclick <- fun _ -> myButton.getAttribute countAttrName |> int |> (+) 1 |> setCount

let addOne x = Some(x + 1)

let log str = console.log(str)

let parseInt str =
    let isSuccessful, number = System.Int32.TryParse str
    if isSuccessful then Some(number) else None

let (>>=) a f = Option.bind f a
let (>>) a f = Option.map f a

let a = parseInt "3"
let b = parseInt "6"
let c = parseInt "4"

let meh = 
    a >>= fun av ->
    b >>= fun bv ->
    c >>= fun cv ->
        Some(av + bv + cv)

"998343" 
    |> parseInt
    >>= addOne
    >>= fun value -> value |> addOne >> fun i -> i + 1
    |> fun opt ->
        match opt with
        | Some value -> value |> string
        | None -> "It was not a valid number"
    |> log
    |> ignore