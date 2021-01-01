module App

open Browser.Dom

let myButton = document.querySelector(".my-button") :?> Browser.Types.HTMLButtonElement

let countAttrName = "data-count"

myButton.setAttribute(countAttrName, 0 |> string)

let setCount cnt =
        myButton.setAttribute(countAttrName, cnt |> string)
        myButton.innerText <- cnt |> sprintf "You clicked: %i time(s)"

myButton.onclick <- fun _ -> myButton.getAttribute countAttrName |> int |> (+) 1 |> setCount

let addOne x = Some(x + 1)

let parseInt str =
    System.Int32.TryParse str
    |> fun (isSuccessful, number) ->
    if isSuccessful then Some(number) else None

let (>>=) a f = Option.bind f a
let (>->) a f = Option.map f a

let a = parseInt "3"
let b = parseInt "6"
let c = parseInt "4"

let log str = console.log(str)

let orInvalidMessage a =
    Option.fold (fun _ value -> value |> string) "It was not a valid number" a

a               >>= (fun av ->
b               >>= fun bv  ->
c >-> (+) 1     >>= fun cv  ->
cv |> addOne    >>= fun d   ->
Some(av + bv + cv + d))
|> orInvalidMessage
|> log

let orZero a = Option.fold (+) 0 a

let mah = a |> orZero

"998343"
|> parseInt
>>= addOne
>-> (+) 1
|> orInvalidMessage
|> log