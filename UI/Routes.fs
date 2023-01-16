module GiraffeHtmxBlazor.UI.Routes

open Giraffe
open Fun.Blazor
open GiraffeHtmxBlazor.UI.Components
open GiraffeHtmxBlazor.UI.Pages

let uiRoutes: HttpHandler =
    choose [
        // For server side partial views
        subRouteCi "/view" (choose [
            routeCi "/empty" >=> cacheFor30Days >=> View.Build html.none
            routeCi "/products" >=> View.Build Products.Create 
            routeCif "/product-editor/%i" (fun id -> View.Build(ProductEditor.Create id))
            routeCi "/stocks" >=> View.Build (html.customElement<StocksView>(preRender = true))
        ])
        // For pages
        routeCi "/dashboard" >=> View.Build Dashboard.Create
        routeCi "/" >=> View.Build Index.Create
    ]
