module App

open Browser.Dom

let myButton = document.querySelector(".my-button") :?> Browser.Types.HTMLButtonElement

let countAttrName = "data-count"

myButton.setAttribute(countAttrName, string 0)

let setCount cnt =
        myButton.setAttribute(countAttrName, string cnt)
        myButton.innerText <- sprintf "You clicked: %i time(s)" cnt
    
myButton.onclick <- fun _ -> myButton.getAttribute countAttrName |> int |> (+) 1 |> setCount
