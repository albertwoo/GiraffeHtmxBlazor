namespace GiraffeHtmxBlazor.UI.Components

open Fun.Htmx
open Fun.Blazor

type Products =

    static member Create () =
        div.create [
            h2 { 
                class' "text-2xl font-medium"
                "Prodution (Loaded async, powered by htmx)" 
            }
            for i in 1..5 do
                div {
                    class' "px-5 py-1 cursor-pointer"
                    hxGet $"ui-comp/product-editor/{i}"
                    hxTrigger hxEvt.mouse.click
                    hxTarget "#product-editor"
                    $"product-{i}"
                }
            div { id "product-editor" }
        ]
