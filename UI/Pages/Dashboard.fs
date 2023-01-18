namespace GiraffeHtmxBlazor.UI.Pages

open Fun.Htmx
open Fun.Blazor
open GiraffeHtmxBlazor.UI.Components

type Dashboard =

    static member Create() =
        let node =
            div {
                class' "container mx-auto py-5"
                childContent [
                    h1 { 
                        class' "text-center text-primary font-semibold"
                        "This is a dashboard with async content and realtime content"
                    }
                    div {
                        hxGet "view/products"
                        hxTrigger (HxTrigger(hxEvt.load, delayMs = 2000))
                        class' "my-5"
                        childContent [
                            p { 
                                class' "text-center w-full"
                                "Loading products ..."
                            }
                            progress { class' "progress progress-primary h-2 mt-1" }
                        ]
                    }
                    div {
                        class' "my-5 rounded shadow-md bg-slate-100 p-5"
                        html.customElement<StocksView>(preRender = true)
                    }
                ]
            }

        Layout.Create(
            headerNode = title { "Dashboard" },
            bodyNode = node
        )
