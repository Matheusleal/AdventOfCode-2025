let instructions_day1 = System.IO.File.ReadAllText (__SOURCE_DIRECTORY__ + "/input_data/day1_secretEntrance.txt")

// let instructions_day1 = 
//     """
//     L68
//     L30
//     R48
//     L5
//     R60
//     L55
//     L1
//     L99
//     R14
//     L82

//     """

SecretEntrance.run instructions_day1
|> printfn "the password is: %d"
