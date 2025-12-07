module SecretEntrance

open StringHelper
open NumberHelper
open OptionHelper

type Direction =
    | Left of int
    | Right of int

type Part =
    | PartOne
    | PartTwo

let parseSpinToDirection (row: string) : Direction option =
    match row[0], tryParseAsInt row[1..] with
    | 'L', Some steps -> Some(Left steps)
    | 'R', Some steps -> Some(Right steps)
    | _ -> None

let partOne (instructions: string) (dialSize: int): int =
    let rotate (delta: int) (maxSize: int) =
        let res = delta % maxSize
        if res < 0 then res + maxSize else res

    let folder ((pos, count): int*int) (direction: Direction): int*int =
        let newPos = 
            match direction with
            | Left steps -> rotate (pos - steps) dialSize
            | Right steps -> rotate (pos + steps) dialSize
        (newPos, if newPos = 0 then count + 1 else count)

    instructions.Split '\n'
    |> Array.map trimText
    |> Array.filter (onlyGreaterThan 1)
    |> Array.map parseSpinToDirection
    |> Array.filter whenSome
    |> Array.map extractValue
    |> Array.fold folder (50, 0)
    |> snd

let partTwo (instructions: string) (dialSize: int): int =
    let rec zeroCrossings (pos: int) (delta: int): int =
        if pos <= delta then
            mathFloorAsInt delta dialSize - mathFloorAsInt pos dialSize
        else
            zeroCrossings (delta - 1) (pos - 1)

    let folder ((pos, count): int*int) (direction: Direction): int*int =
        let movement = 
            match direction with
            | Left steps -> -steps
            | Right steps -> steps

        let delta = pos + movement
        let crossings = zeroCrossings pos delta

        (delta, count + crossings)

    instructions.Split '\n'
    |> Array.map trimText
    |> Array.filter (onlyGreaterThan 1)
    |> Array.map parseSpinToDirection
    |> Array.filter whenSome
    |> Array.map extractValue
    |> Array.fold folder (50, 0)
    |> snd

let run (path: string): int*int = 
    let instructions_day1 = System.IO.File.ReadAllText path
    //let instructions_day1 = "
    //L68
    //L30
    //R48
    //L5
    //R60
    //L55
    //L1
    //L99
    //R14
    //L82
    
    //"

    let partOneResult = partOne instructions_day1 100
    let partTwoResult = partTwo instructions_day1 100 

    (partOneResult, partTwoResult)
