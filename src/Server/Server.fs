module Server

open Giraffe
open Saturn
open Npgsql.FSharp

open Shared

type Storage() =
    let blotters = ResizeArray<_>()
    let markets = ResizeArray<_>()

    member __.GetBlotters() = List.ofSeq blotters
    
    member __.GetMarkets() = List.ofSeq markets

    member __.AddBlotter(data : Blotter) =
        blotters.Add data
        Ok()

    member __.AddMarket(dataMarket : Market) =
        markets.Add dataMarket
        Ok()

let storage = Storage()        

let loadBlottersInfo =
    [ { Id = System.Guid();
        DateTime = System.DateTime()
        Price = 1.4528;
        Quantity = 1500;
        Pair = "GBP/USD" } ]

let loadMarketsInfo =
    [ { Id = System.Guid();
        Provider = "CBOE";
        Pair = "GBP/USD";
        Price = 1.554;
        Time = System.DateTime() } ]

let blottersApi =
        { getBlotters = fun () -> async { return storage.GetBlotters() }}

storage.AddBlotter(Blotter.create (System.DateTime()) 1.4528 1500 "GBP/USD")
|> ignore

let webApp =
    router {
        get Route.blotters (json (storage.GetBlotters))
        // get Route.markets (json (loadMarketsInfo))
        get Route.markets (json (storage.GetBlotters))
        post Route.newblotters (json (storage.AddBlotter))
        post Route.newmarkets (json (storage.AddMarket))
    }

let app =
    application {
        url "http://0.0.0.0:8085"
        use_router webApp
        memory_cache
        use_static "public"
        use_gzip
    }

run app

let connectionString : string =
    Sql.host "localhost"
    |> Sql.database "dvdrental"
    |> Sql.username "postgres"
    |> Sql.password "postgres"
    |> Sql.port 5432
    |> Sql.formatConnectionString

let getAllBlotters (connectionString: string) : Blotter list =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT * FROM blotters"
    |> Sql.execute (fun read ->
        {
            Id = System.Guid "blotter_id"
            DateTime = read.dateTime "date_time"
            Price = read.float "price"
            Quantity = read.int "quantity"
            Pair = read.string "pair"
        })

let getAllMarkets (connectionString: string) : Market list =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT * FROM markets"
    |> Sql.execute (fun read ->
        {
            Id = System.Guid "market_id"
            Provider = read.string "provider"
            Pair = read.string "pair"
            Price = read.float "price"
            Time = read.dateTime "date_time"
        })