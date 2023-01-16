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
                        class' "text-3xl text-primary font-semibold my-10"
                        "This is a dashboard with async content and realtime content"
                    }
                    div {
                        hxGet "ui-comp/products"
                        hxTrigger (HxTrigger(hxEvt.load, delayMs = 2000))
                        hxTarget_this
                        hxSwap_innerHTML
                        childContent [
                            p { 
                                class' "text-center w-full"
                                "Loading products ..."
                            }
                            progress {
                                id "products-loader"
                                class' "progress progress-primary h-2 mt-1"
                            }
                        ]
                    }
                    div {
                        class' "my-5 rounded shadow-md bg-slate-100 p-5"
                        html.customElement<StocksView>(preRenderNode = div {
                            "Loading stocks"
                            progress { "progress h-2" }
                        })
                    }
                ]
            }

        Layout.Create(
            headerAttrs = domAttr {
                title' "Dashboard"
                asAttrRenderFragment
            },
            bodyNode = node
        )
