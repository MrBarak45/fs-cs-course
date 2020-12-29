open FSharp.Data
open System.IO

type car = CsvProvider<"cars.csv", HasHeaders=true>

let getOrigins (db:car) =
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let res =
        db.Rows
        |> Seq.map(fun row -> row.Origin)
        |> Seq.distinct
    stopwatch.Stop()
    printfn "Toutes les origines ont été trouvées en %f s" stopwatch.Elapsed.TotalSeconds
    res

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

let carToStr (car:car.Row) = 
    let res = car.Car.ToString()+","+car.MPG.ToString()+","+car.Cylinders.ToString()+","+car.Displacement.ToString()+","+car.Horsepower.ToString()+","+car.Weight.ToString()+","+car.Acceleration.ToString()+","+car.Model.ToString()+","+car.Origin
    res

let deleteDuplicates (db:car) =
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let res = db.Rows |> Seq.distinct 
    let path = "C:\\Users\\petit\\OneDrive\\Bureau\\Nouveau dossier (2)\\noDuplicateFSharp.csv"
    File.WriteAllLines(path, res |> Seq.map carToStr) |> ignore
    stopwatch.Stop()
    printfn "Les doublons ont été supprimés en %f s"  stopwatch.Elapsed.TotalSeconds

[<EntryPoint>]
let main argv =
    let db = car.GetSample()
    //let Cars = getLightestCarsAndBiggestCylindersForEachCountry (getOrigins db |> Seq.toList) db
    //printfn "%A" (Cars)
    deleteDuplicates db
    0 // return an integer exit code
    
