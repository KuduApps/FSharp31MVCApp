namespace FSharp31MVCTest.Controllers
open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open Microsoft.FSharp.Data.TypeProviders

// Test for F# 3.1
type Shape =
    | Rectangle of width : float * length : float
    | Circle of radius : float
    | Prism of width : float * float * height : float

// Test for WsdlService
type terraService = Microsoft.FSharp.Data.TypeProviders.WsdlService<"http://api.microsofttranslator.com/V2/Soap.svc">

/// Retrieves values.
[<RoutePrefix("api2/values")>]
type ValuesController() =
    inherit ApiController()
    let values = [|"value1";"value2"|]

    /// Gets all values.
    [<Route("")>]
    member x.Get() = values

    /// Gets the value with index id.
    [<Route("{id:int}")>]
    member x.Get(id) : IHttpActionResult =
        if id > values.Length - 1 then
            x.BadRequest() :> _
        else x.Ok(values.[id]) :> _