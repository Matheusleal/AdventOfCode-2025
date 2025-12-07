module NumberHelper

open System

    let tryParseAsInt (text: string) : int option =
        let parsed, value = System.Int32.TryParse text
        if parsed then Some value else None

    let mathFloorAsInt a b = Math.Floor(float a / float b) |> int