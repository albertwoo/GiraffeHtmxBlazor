namespace GiraffeHtmxBlazor.UI.Components

open System
open System.Threading
open Fun.Blazor

type StocksView() =
    inherit FunBlazorComponent()

    override _.Render() =
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
