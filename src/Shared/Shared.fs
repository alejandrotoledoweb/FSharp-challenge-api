namespace Shared
open System

module Route =
    let blotters = "/api/blotters"
    let newblotters = "/api/new/blotters"
    let markets = "/api/markets"
    let newmarkets = "/api/new/markets"

type Blotter = { Id: Guid; DateTime: DateTime; Price: float; Quantity: int; Pair: string }

type Market = { Id: Guid; Provider: string; Pair: string; Price: float; Time: DateTime}

module Blotter =
    let create dateTime price quantity pair =
        { Id = Guid.NewGuid()
          DateTime = dateTime
          Price = price
          Quantity = quantity
          Pair = pair }

module Market =
    let create provider pair price time =
        { Id = Guid.NewGuid()
          Provider = provider
          Pair = pair
          Price = price
          Time = time }

type IBlottersApi =
    { 
        getBlotters: unit -> Async<Blotter list>
    }

