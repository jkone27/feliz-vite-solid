module Componenents

open Feliz.JSX.Solid
open Fable.Core.JsInterop
open Fable.Core

[<JSX.Component>]
let Counter() =
    let count, setCount = Solid.createSignal(0)

    Html.div [
        Attr.className "card"
        Html.children [
            Html.h2 "I am a counter from: Counter.fs"
            Html.button [
                Ev.onClick (fun _ -> setCount (count() + 1))
                Html.children [
                    Html.text $"count is {count()}"
                ]
            ]
            Html.div [
                Html.text "Edit "
                Html.code "src/components/Counter.fs"
                Html.text " and save to test HMR"
            ]
        ]
    ]