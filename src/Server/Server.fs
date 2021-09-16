module Server

open Giraffe
open Saturn
open FSharp.Control.Tasks

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

// let getBlotters next ctx =
//     json (loadBlottersInfo()) next ctx

// let getMarkets next ctx =
//     json (loadMarketsInfo()) next ctx

let webApp =
    router {
        get Route.hello (text "Hello from SAFE!")
        get Route.blotters (json (loadBlottersInfo))
        get Route.markets (json (loadMarketsInfo))
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
