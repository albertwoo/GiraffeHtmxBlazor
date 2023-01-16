namespace GiraffeHtmxBlazor.UI.Components

open Fun.Blazor

type Layout =

    static member Create (?headerAttrs: AttrRenderFragment, ?bodyNode: NodeRenderFragment) =
        fragment {
            doctype "html"
            html' {
                head {
                    title { "GiraffeHtmxBlazor" }
                    //defaultArg headerAttrs (AttrRenderFragment(fun _ _ i -> i))
                    baseUrl "/"
                    meta { charset "utf-8" }
                    meta {
                        name "viewport"
                        content "width=device-width, initial-scale=1.0"
                    }
                    stylesheet "tailwind-generated.css"
                    CustomElement.lazyBlazorJs ()
                }
                body {
                    nav {
                        class' "flex items-center gap-3 container mx-auto p-2"
                        childContent [
                            a {
                                class' "text-primary text-lg font-medium"
                                href ""
                                "Demo App"
                            }
                            div { class' "flex-grow" }
                            a {
                                class' "link link-primary"
                                href ""
                                "Home"
                            }
                            a {
                                class' "link link-primary"
                                href "dashboard"
                                "Dashboard"
                            }
                        ]
                    }
                    defaultArg bodyNode (NodeRenderFragment(fun _ _ i -> i))
                    script { src "https://unpkg.com/htmx.org@1.8.4" }
                }
            }
        }