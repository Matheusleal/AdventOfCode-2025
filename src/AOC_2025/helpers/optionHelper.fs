module OptionHelper
    let whenSome (optional: 'a option) = optional.IsSome
    let whenNone (optional: 'a option) = optional.IsNone

    let extractValue (optional: 'a option) = optional.Value