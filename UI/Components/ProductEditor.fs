namespace GiraffeHtmxBlazor.UI.Components

open Fun.Htmx
open Fun.Blazor

type ProductEditor =

    static member Create (productId: int) =
        div {
            class' "modal modal-open"
            div {
                class' "modal-box"
                childContent [
                    h3 {
                        class' "font-bold text-lg"
                        $"Product {productId} detail"
                    }
                    p {
                        class' "py-4"
                        "There should have a lot of production details..."
                    }
                    div {
                        class' "modal-action"
                        childContent [
                            button {
                                hxGet "view/empty"
                                hxTarget "#product-editor"
                                hxTrigger hxEvt.mouse.click
                                class' "btn"
                                "Close"
                            }
                        ]
                    }
                ]
            }
        }
