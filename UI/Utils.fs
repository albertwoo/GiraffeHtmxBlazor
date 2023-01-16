[<AutoOpen>]
module GiraffeHtmxBlazor.UI.Utils

open Giraffe
open Microsoft.Extensions.DependencyInjection

let dom node: HttpHandler =
    fun nxt ctx -> task {
        do! ctx.WriteFunDom(node)
        return! nxt ctx
    }
