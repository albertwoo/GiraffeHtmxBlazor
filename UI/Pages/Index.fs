namespace GiraffeHtmxBlazor.UI.Pages

open Fun.Htmx
open Fun.Blazor
open GiraffeHtmxBlazor.UI.Components

type Index =

    static member Create() =
        Layout.Create(
            bodyNode = div {
                class' "container mx-auto py-5"
                h1 {
                    class' "text-primary text-center font-medium"
                    "This is a demo app, just for try to mix Giraffe, htmx, Fun.Blazor"
                }
                div {
                    class' "my-5 rounded shadow-md bg-slate-100 p-5"
                    html.customElement<StocksView>(preRenderNode = div {
                        "Loading stocks ..."
                        progress { class' "progress h-2" }
                    })
                }
                div {
                    hxGet "view/stocks"
                    hxTarget "#lazy-stock-status"
                    hxTrigger (HxTrigger(hxEvt.load, delayMs = 3_000))
                    class' "my-5 rounded shadow-md bg-slate-100 p-5"
                    childContent [
                        ul { 
                            li { "- display progress bar for 3s" }
                            li { "- insert the prerendered stock status" }
                            li { "- blazor will kick in by registered custom element" }
                        }
                        div {
                            id "lazy-stock-status"
                            "Loading stocks ..."
                            progress { class' "progress h-2" }
                        }
                    ]
                }
            }
        )
