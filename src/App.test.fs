namespace App

open Fable.Core.JsInterop
open Fable.Core
open Feliz.JSX.Solid

// https://vitest.dev/config/#environment
// https://docs.solidjs.com/guides/testing
// https://github.com/fable-compiler/Feliz.JSX
// https://fable.io/blog/2022/2022-10-18-fable-solid.html
// https://github.com/fable-compiler/Fable.Solid

// IMPORTANT! https://fable.io/docs/javascript/features.html

// as inspiration for types: https://github.com/Shmew/Fable.Jester/blob/master/src/Fable.Jester/Expect.fs

module Dom =
    open Fable.Core.JsInterop
    open Fable.Core

    type IRenderResult = 
        abstract getByText: string -> obj
        abstract getByRole: string -> obj

    type DomEvent = {
        click: obj -> unit
    }

    [<Import("render", from = "@solidjs/testing-library")>]
    let render (fableComponent: obj) : IRenderResult = jsNative

    [<Import("cleanup", from = "@solidjs/testing-library")>]
    let cleanup(): unit = jsNative

    [<Import("screen", from = "@solidjs/testing-library")>]
    let screen: IRenderResult = jsNative

    [<Import("fireEvent", from = "@solidjs/testing-library")>]
    let fireEvent: DomEvent = jsNative

// for each Fable import try to match JS signature and try create 
// correct types based on original typescript definitions but as F# types e.g. record types

module Vi = 
    type IMatcherResult =
        abstract toBe: obj -> unit
        abstract toEqual: obj -> unit
        abstract toMatchObject: obj -> unit
        abstract toHaveBeenCalled: unit -> unit
        abstract toHaveBeenCalledWith: obj -> unit
        abstract toHaveBeenCalledTimes: int -> unit
        abstract toBeInTheDocument: unit -> unit
        abstract toHaveTextContent: string -> unit
        abstract toHaveClass: string -> unit
        abstract toHaveStyle: string -> unit
        abstract toHaveAttribute: string -> unit
        abstract toHaveProperty: string -> unit
        abstract toHaveValue: string -> unit
        abstract toHaveFocus: unit -> unit
        abstract toHaveFormValues: obj -> unit
        abstract toHaveLength: int -> unit
        abstract toBeDisabled: unit -> unit
        abstract toBeEnabled: unit -> unit
        abstract toBeVisible: unit -> unit
        abstract toBeEmpty: unit -> unit
        abstract toBeChecked: unit -> unit
        abstract toBeSelected: unit -> unit
        abstract toBeTruthy: unit -> unit
        abstract toBeFalsy: unit -> unit
        abstract toBeNull: unit -> unit
        abstract toBeUndefined: unit -> unit
        abstract toBeNaN: unit -> unit
        abstract toBeGreaterThan: obj -> unit
        abstract toBeLessThan: obj -> unit
        abstract toBeGreaterThanOrEqual: obj -> unit
        abstract toBeLessThanOrEqual: obj -> unit
        abstract toBeCloseTo: obj -> unit

    [<Import("expect", from = "vitest")>]
    let expect(value: obj): IMatcherResult = jsNative

    [<Import("toBeInTheDocument", from = "@testing-library/jest-dom/matchers")>]
    let toBeInTheDocument: obj = jsNative

    // Extension method for expect
    [<Emit("$0.toBeInTheDocument()")>]
    let inline expectToBeInTheDocument (value: obj): obj = jsNative

    [<Import("beforeEach", from = "vitest")>]
    let beforeEach(test: unit -> unit) = jsNative

    [<Import("afterEach", from = "vitest")>]
    let afterEach(test: unit -> unit) = jsNative

    [<Import("beforeAll", from = "vitest")>]
    let beforeAll(test: unit -> unit) = jsNative

    [<Import("afterAll", from = "vitest")>]
    let afterAll(test: unit -> unit) = jsNative

    [<Import("it", from = "vitest")>]
    let it(name: string, test: unit -> unit) = jsNative

    [<Import("test", from = "vitest")>]
    let test(name: string, test: unit -> unit) = jsNative

    [<Import("describe", from = "vitest")>]
    let describe(name: string, testSuite: unit -> unit) = jsNative 


module Test =

    Vi.describe("render app and increment count", fun () ->

        let element = Dom.render(App())
            
        Vi.test("should render initial count", fun () ->
            let countElement = element.getByText("count is 0")
            Vi.expect(countElement).toBeInTheDocument()
        )

        Vi.test("should increment count on button click", fun () ->
            let buttonElement = element.getByRole("button" )
            Dom.fireEvent.click(buttonElement)
            let updatedButtonElement = element.getByText("count is 1")
            Vi.expect(updatedButtonElement).toBeInTheDocument()
        )
    )