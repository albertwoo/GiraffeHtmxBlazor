namespace GiraffeHtmxBlazor.UI.Components

open Fun.Blazor

type Layout =

    static member Create (?headerNode: NodeRenderFragment, ?bodyNode: NodeRenderFragment) =
        html.fragment [
            doctype "html"
            html' {
                head {
                    chartsetUTF8
                    baseUrl "/"
                    viewport "width=device-width, initial-scale=1.0"
                    stylesheet "tailwind-generated.css"
                    CustomElement.lazyBlazorJs ()
                    defaultArg headerNode (title { "GiraffeHtmxBlazor" })
                }
                body {
                    nav {
                        class' "flex items-center gap-3 container mx-auto py-2"
                        childContent [
                            a {
                                href ""
                                class' "text-primary text-lg font-medium"
                                "GiraffeHtmxBlazor"
                            }
                            div { class' "flex-grow" }
                            a {
                                href ""
                                class' "link link-primary"
                                "Home"
                            }
                            a {
                                href "dashboard"
                                class' "link link-primary"
                                "Dashboard"
                            }
                        ]
                    }
                    defaultArg bodyNode (NodeRenderFragment(fun _ _ i -> i))
                    script { src "https://unpkg.com/htmx.org@1.8.5" }
                }
            }
        ]
