namespace GiraffeHtmxBlazor.UI.Components

open Giraffe
open Fun.Htmx
open Fun.Blazor
open GiraffeHtmxBlazor.UI

type ProductEditor =

    static member Create (productId: int): HttpHandler =
        fun nxt ctx -> task {
            let node =
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
                                        class' "btn"
                                        hxGet "ui-comp/empty"
                                        hxTrigger hxEvt.mouse.click
                                        hxTarget "#product-editor"
                                        "Yay!"
                                    }
                                ]
                            }
                        ]
                    }
                }
        
            return! dom node nxt ctx
        }


