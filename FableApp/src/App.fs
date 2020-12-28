module App

open Browser.Dom

// Mutable variable to count the number of times we clicked the button
let mutable count = 0

// Get a reference to our button and cast the Element to an HTMLButtonElement
let myButton = document.querySelector(".my-button") :?> Browser.Types.HTMLButtonElement

let countAttrName = "data-count"

myButton.setAttribute(countAttrName, string 0)

let setCount = 
    fun cnt -> 
        myButton.setAttribute(countAttrName, string cnt)
        myButton.innerText <- sprintf "You clicked: %i time(s)" cnt

let increaseCount = fun _ -> 
    myButton.getAttribute countAttrName |> int |> (+) 1 |> setCount
    
  //  |> Option.fold (fun unit c -> c + 1 |> string |> myButton.setAttribute "data-count" |> ignore)
// Register our listener
myButton.onclick <- increaseCount
