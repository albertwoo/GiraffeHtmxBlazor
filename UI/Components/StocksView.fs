[<AutoOpen>]
module GiraffeHtmxBlazor.UI.Components.StocksView

open System
open System.Threading
open Fun.Blazor

let private stocksView = 
    html.inject (fun (hook: IComponentHook) ->
        let mutable price = 0.

        hook.AddFirstAfterRenderTask(fun _ -> task {
            hook.AddDispose(
                new Timer(
                    (fun _ ->
                        price <- Random.Shared.NextDouble()
                        hook.StateHasChanged()
                    ),
                    null, 0, 1000
                )
            )
        })
            
        div {
            childContent [
                h2 { 
                    class' "text-2xl font-medium"
                    "Stock status (Rendered in real time, powered by blazor server)"
                }
                p { $"Price = {price}" }
            ]
        }
    )

type StocksView() =
    inherit FunBlazorComponent()

    override _.Render() = stocksView
