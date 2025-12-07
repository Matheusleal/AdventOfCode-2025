
let baseInputPath = $"{__SOURCE_DIRECTORY__}/input_data"
let day1InputPath = $"{baseInputPath}/day1_secretEntrance.txt"

printfn "AOC 2025 - f# version"
let day1res = SecretEntrance.run day1InputPath
printfn $"""
[Day 1] The passwords are:
    part 1: {fst day1res}
    part 2: {snd day1res}
"""
printf "----------------------------------------------------\n"