module FSharp31MVCTest.Models

module dbModel = 
    open Microsoft.FSharp.Data.TypeProviders

    // Test for Microsoft.FSharp.Data.TypeProviders
    type Northwind = ODataService<"http://services.odata.org/Northwind/Northwind.svc/">

    let db = Northwind.GetDataContext()
    let fullContext = Northwind.ServiceTypes.NorthwindEntities()

    query { for customer in db.Customers do
            select customer }
    |> Seq.iter (fun customer ->
        printfn "ID: %s\nCompany: %s" customer.CustomerID customer.CompanyName
        printfn "Contact: %s\nAddress: %s" customer.ContactName customer.Address
        printfn "         %s, %s %s" customer.City customer.Region customer.PostalCode
        printfn "%s\n" customer.Phone)

