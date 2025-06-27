module App

open Feliz.JSX.Solid
open Fable.Core.JsInterop
open Fable.Core

importAll "./App.css"

let viteLogo: string = importDefault "./assets/vite.svg"
let solidLogo: string = importDefault "./assets/solid.svg"


let Counter() : JSX.Element = import "Counter" "./components/Counter.fs"


[<JSX.Component>]
let App() =
    let count, setCount = Solid.createSignal(0)

    Html.fragment [
        Html.div [
            Html.a [
                Attr.href "https://vite.dev"
                Attr.target "_blank"
                Html.children [
                    Html.img [
                        Attr.src viteLogo
                        Attr.className "logo"
                        Attr.alt "Vite logo"
                    ]
                ]
            ]
            Html.a [
                Attr.href "https://solidjs.com"
                Attr.target "_blank"
                Html.children [
                    Html.img [
                        Attr.src solidLogo
                        Attr.className "logo solid"
                        Attr.alt "Solid logo"
                    ]
                ]
            ]
            Html.a [
                Attr.href "https://fable.io/vite-plugin-fable"
                Attr.target "_blank"
                Html.children [
                    Html.img [
                        Attr.src "https://fable.io/vite-plugin-fable/img/logo.png"
                        Attr.className "logo fable"
                        Attr.alt "Fable vite plugin logo"
                    ]
                ]
            ]
        ]
        Html.h1 "Vite + Solid + Feliz"
        Counter()
        Html.p [
            Attr.className "read-the-docs"
            Html.children [
                Html.text "Click on the logos to learn more"
            ]
        ]
    ]