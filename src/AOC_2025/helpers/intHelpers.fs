module IntHelper

    let tryParse (text: string) : int option =
        let parsed, value = System.Int32.TryParse text
        if parsed then Some value else None