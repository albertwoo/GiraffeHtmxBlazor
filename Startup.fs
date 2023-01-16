#nowarn "0020"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Giraffe
open GiraffeHtmxBlazor.UI.Components

let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())
let services = builder.Services

services.AddControllersWithViews()
services.AddServerSideBlazor(fun options ->
    options.RootComponents.RegisterCustomElementForFunBlazor<StocksView>()
)
services.AddFunBlazorServer()
services.AddGiraffe()


let app = builder.Build()

app.UseResponseCaching()

app.UseStaticFiles()

app.UseGiraffe(GiraffeHtmxBlazor.UI.Routes.uiRoutes)

app.MapBlazorHub()

app.Run()
