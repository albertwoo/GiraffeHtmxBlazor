#nowarn "0020"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Giraffe
open GiraffeHtmxBlazor.UI.Components


let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddControllersWithViews()
builder.Services.AddHttpContextAccessor()
builder.Services.AddServerSideBlazor(fun options ->
    options.RootComponents.RegisterCustomElementForFunBlazor<StocksView>()
)
builder.Services.AddFunBlazorServer()
builder.Services.AddGiraffe()


let app = builder.Build()

app.UseStaticFiles()

app.UseGiraffe(GiraffeHtmxBlazor.UI.Routes.uiRoutes)

app.MapBlazorHub()

app.Run()
