module GiraffeHtmxBlazor.UI.Routes

open Giraffe
open Fun.Blazor
open GiraffeHtmxBlazor.UI.Components
open GiraffeHtmxBlazor.UI.Pages


let private (>=>>) handler node = handler >=> dom node


let uiRoutes: HttpHandler =
    choose [
        // For server side partial views
        subRouteCi "/ui-comp" (choose [
            routeCi "/empty" >=>> html.none
            routeCi "/products" >=>> Products.Create() 
            routeCif "/product-editor/%i" ProductEditor.Create
        ])
        // For pages
        routeCi "/dashboard" >=>> Dashboard.Create()
        routeCi "/" >=>> Index.Create()
    ]
