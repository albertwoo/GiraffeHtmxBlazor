namespace GiraffeHtmxBlazor.UI.Components

open Fun.Htmx
open Fun.Blazor

type Products =

    static member Create () =
        div.create [
            h2 { 
                class' "text-xl font-medium"
                "Prodution (Loaded async, powered by htmx)" 
            }
            for i in 1..5 do
                div {
                    hxGet $"view/product-editor/{i}"
                    hxTarget "#product-editor"
                    hxTrigger hxEvt.mouse.click
                    class' "px-5 py-1 my-1 cursor-pointer rounded bg-slate-100 hover:bg-slate-300"
                    $"product-{i}"
                }
            div { id "product-editor" }
        ]
