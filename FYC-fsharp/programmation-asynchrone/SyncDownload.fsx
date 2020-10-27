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

let fetchUrl url = 
    let request = WebRequest.Create(System.Uri url)
    use response = request.GetResponse()
    use stream = response.GetResponseStream()
    use reader = new StreamReader(stream)
    let html = reader.ReadToEnd()
    //normalement on retourne l'html ici
    printfn "telechargement termine %s" url
    

#time
sites
|> List.map fetchUrl
#time

    
