[<AutoOpen>]
module GiraffeHtmxBlazor.UI.Components.StocksView

open System
open System.Threading
open FSharp.Data.Adaptive
open Fun.Blazor

let private price = cval 0.

let private stocksView = 
    html.inject (fun (hook: IComponentHook) ->

        hook.AddFirstAfterRenderTask(fun _ -> task {
            hook.AddDispose(
                new Timer(
                    (fun _ -> price.Publish(Random.Shared.NextDouble())),
                    null, 0, 1000
                )
            )
        })
            
        div.create [
            h2 { 
                class' "text-2xl font-medium"
                "Stock status (Rendered in real time, powered by blazor server custom elements)"
            }
            adaptiview () {
                let! price = price
                p { $"Price = {price}" }
            }
        ]
    )

type StocksView() =
    inherit FunBlazorComponent()

    override _.Render() = stocksView
