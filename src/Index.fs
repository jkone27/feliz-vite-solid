module Index

open Browser.Dom
open App
open Fable.Core.JsInterop
open Fable.Core

importAll "./index.css"

let doc = document.getElementById "root"
Solid.render (App, doc)