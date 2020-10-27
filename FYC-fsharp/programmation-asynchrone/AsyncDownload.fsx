open System.Net
open System.IO

//liste des sites web pour telecharger
let sites = [
    "http://www.bing.com";
    "http://www.google.com";
    "http://www.microsoft.com";
    "http://www.amazon.com";
    "http://www.yahoo.com"
]

let fetchUrlAsync url =
    async{
        let req = WebRequest.Create(System.Uri url)
        use! response = req.AsyncGetResponse()
        use stream = response.GetResponseStream()
        use reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        printfn "telechargement termine %s" url
    }
    

#time
sites
|> List.map fetchUrlAsync
|> Async.Parallel
|> Async.RunSynchronously
#time

    

