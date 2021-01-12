namespace FsParser_Library

open FSharp.Data
open System

//Schema=""
// Schema="Emp ID, First Name, Last Name, Gender, E Mail, Date of Birth, Date of Joining, Age in Company, Phone, Place Name, County, City, State, Region, User Name, Password"
type people = CsvProvider<"Members.csv", HasHeaders=true, Schema="">


module FSParser =
    let getData (path:string) =
        let res = people.Load(path)
        res

    let getStates (db:people) =
        let res =
            db.Rows
            |> Seq.map(fun row -> row.State)
            |> Seq.distinct
        res

    let getPeopleByState (db:people) state =
        let res = 
            db.Rows
            |> Seq.filter(fun row -> row.State.Equals(state))
        res

    let getPeopleAgeHigherThan (db:people) age =
        let res = 
            db.Rows
            |> Seq.filter(fun row -> row.``Age in Company (Years)`` >= age)
        res

    let getPeopleFromStateAndAgeHigerThan (db:people) state age = 
        let res =
            db.Rows
            |> Seq.filter(fun row -> row.State.Equals(state))
            |> Seq.filter(fun row -> row.``Age in Company (Years)`` >= age)
        res

    let intersect res1 res2 = 
        let rec helper xs ys res = 
            match xs with 
            |head::tail -> 
                if ys |> Seq.exists((=) head) then helper tail ys (head::res) 
                else helper tail ys res
            | _ -> res
        let res = helper res1 res2 []
        res

    let getResults (db:people) states age= 
        let rec helper states age (res:Map<String, seq<people.Row>>) : Map<String, seq<people.Row>> =
            match states with
            | [] -> res
            | head :: tail ->
                let toAdd = getPeopleFromStateAndAgeHigerThan db head age
                helper tail age (res.Add(head, toAdd))
        let res = helper states age Map.empty
        res
    
    let getParsedResults() =
        let db = getData "../../../Members.csv"
        let states = getStates db
        let res = getResults db (states|>Seq.toList) (decimal 20)
        res
    

(*
[<EntryPoint>]
let main argv =
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let db = getData "../../../Members.csv"
    let states = getStates db
    let res = getResults db (states|>Seq.toList) (decimal 20)
    stopwatch.Stop()
    let keys = res |> Map.toSeq |> Seq.map fst
    keys |> Seq.iter(fun x -> printfn "%A" res.[x])
    printfn "Operation effectuee en : %f s" stopwatch.Elapsed.TotalSeconds
    res |> ignore
    0 
*)
