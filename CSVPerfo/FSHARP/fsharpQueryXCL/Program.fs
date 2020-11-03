﻿// Learn more about F# at http://fsharp.org
open FSharp.Data

type car = CsvProvider<"cars.csv", HasHeaders=true>

let getByOrigin origin (db:car)= 
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let res =
        db.Rows 
        |> Seq.filter(fun row -> row.Origin.Equals(origin)) 
    stopwatch.Stop()
    printfn "Toutes les voitures ayant pour origine : %s ont été trouvées en %f s" origin stopwatch.Elapsed.TotalSeconds
    res

let getBiggestCylinderByOrigin origin (db:car) =
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let res =
        db.Rows 
        |> Seq.filter(fun row -> row.Origin.Equals(origin)) 
        |> Seq.maxBy(fun row -> row.Horsepower)
    stopwatch.Stop()
    printfn "La plus grosse cylindrée ayant pour origine : %s a été trouvée en %f s" origin stopwatch.Elapsed.TotalSeconds
    res

//sortir la voiture la moins lourde mais la plus cylindré par pays d'origine(modifié)
let getLightestCarAndBiggestCylindersByCountry origin (db:car)=
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let res =
        db.Rows 
        |> Seq.filter(fun row -> row.Origin.Equals(origin)) 
        |> Seq.sortBy(fun row -> row.Weight)
        |> Seq.maxBy(fun row -> row.Cylinders)
    stopwatch.Stop()
    printfn "La plus légère grosse cylindrée ayant pour origine : %s a été trouvée en %f s" origin stopwatch.Elapsed.TotalSeconds
    res

let getLightestCarsAndBiggestCylindersForEachCountry origins (db:car)=
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let rec helper origins (res:List<car.Row>) : List<car.Row> =
        match origins with 
            | [] -> res
            | head :: tail -> 
                let toAdd = getLightestCarAndBiggestCylindersByCountry head db
                helper tail (toAdd::res)
    let res = helper origins []
    stopwatch.Stop()
    printfn "L'opération a été effectuée en %f s"  stopwatch.Elapsed.TotalSeconds
    res

[<EntryPoint>]
let main argv =
    let db = car.GetSample()
    let countries = ["US"; "Japan"; "Europe"]
    let Cars = getLightestCarsAndBiggestCylindersForEachCountry countries db
    printfn "%A" (Cars)
    0 // return an integer exit code
    
