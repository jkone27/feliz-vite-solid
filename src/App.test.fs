namespace App

open Fable.Core
open Testing

module Test =

    Vi.describe("render app and increment count", fun () ->

        Vi.afterAll(fun () ->
            Dom.cleanup()
        )

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