module StringHelper

    let trimText (text: string) : string = text.Trim()

    let onlyGreaterThan (size: int) (text: string) : bool = text.Length > size