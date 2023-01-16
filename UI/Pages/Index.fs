namespace GiraffeHtmxBlazor.UI.Pages

open Fun.Blazor
open GiraffeHtmxBlazor.UI.Components

type Index =

    static member Create() =
        Layout.Create(
            bodyNode = div {
                class' "container mx-auto p-10"
                h1 {
                    class' "text-3xl text-primary font-medium"
                    "This is a demo app, just for try to mix Giraffe, htmx, Fun.Blazor"
                }
                div {
                    class' "my-5 rounded shadow-md bg-slate-100 p-5"
                    html.customElement<StocksView>(preRenderNode = div {
                        "Loading stocks"
                        progress { "progress h-2" }
                    })
                }
            }
        )
