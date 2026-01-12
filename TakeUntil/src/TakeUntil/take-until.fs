namespace TakeUntil

module Seq =
    [<CompiledName("TakeUntil")>]
    let takeUntil (predicate: 'T -> bool) (source: 'T seq) : 'T seq =
        if isNull source then
            nullArg <| nameof source

        seq {
            use e = source.GetEnumerator()

            let mutable latest = Unchecked.defaultof<_>
            let mutable ok = true

            while ok && e.MoveNext() do
                latest <- e.Current
                yield latest
                ok <- not <| predicate latest
        }

module List =
    [<CompiledName("TakeUntil")>]
    let takeUntil (predicate: 'T -> bool) (list: 'T list) : 'T list =
        match List.tryFindIndex predicate list with
        | None -> list
        | Some ix -> List.take (ix + 1) list

module Array =
    [<CompiledName("TakeUntil")>]
    let takeUntil (predicate: 'T -> bool) (array: 'T array) : 'T array =
        match Array.tryFindIndex predicate array with
        | None -> array
        | Some ix -> Array.take (ix + 1) array
