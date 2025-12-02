module SecretEntrance

open StringHelper
open IntHelper

type Direction =
    | Left of int
    | Right of int

let run (instructions: string) =

    let parseSpin (row: string) : Direction option =
        match row[0], tryParse row[1..] with
        | 'L', Some steps -> Some(Left steps)
        | 'R', Some steps -> Some(Right steps)
        | _ -> None

    let rotateDial (dialSize: int) (currentPosition: int) (direction: Direction) : int =
        let rotate (value: int) (delta: int) : int =
            let res = (value + delta) % dialSize
            if res < 0 then res + dialSize else res

        match direction with
        | Left step -> rotate currentPosition -step
        | Right step -> rotate currentPosition step

    let findCombination (dialSize: int) (startingPosition: int) (combinations: Direction option list) =
        let rec execute (combinations: Direction option list) (clicks: int) (pos: int)  =
            match combinations with
            | Some head :: tail ->
                let newPos = rotateDial dialSize pos head
                execute tail (if newPos = 0 then clicks + 1 else clicks) newPos 
            | _ -> clicks
        execute combinations 0 startingPosition

    instructions.Split '\n'
    |> Seq.map trimText
    |> Seq.filter (onlyGreaterThan 1)
    |> Seq.map parseSpin
    |> Seq.toList
    |> findCombination 100 50
