namespace TakeUntil

module Seq =
    [<CompiledName("TakeUntil")>]
    let takeUntil (predicate: 'T -> bool) (source: 'T seq) : 'T seq =
        if isNull source then
            nullArg <| nameof source

        seq {
            use e = source.GetEnumerator()

            let mutable latest = Unchecked.defaultof<'T>
            let mutable proceed = true

            while proceed && e.MoveNext() do
                latest <- e.Current
                yield latest
                proceed <- not <| predicate latest
        }

module List =
    [<CompiledName("TakeUntil")>]
    let takeUntil (predicate: 'T -> bool) (list: 'T list) : 'T list =
        match List.tryFindIndex predicate list with
        | None -> list
        | Some n -> List.take (n + 1) list

module Array =
    [<CompiledName("TakeUntil")>]
    let takeUntil (predicate: 'T -> bool) (array: 'T array) : 'T array =
        match Array.tryFindIndex predicate array with
        | None -> array
        | Some n when n + 1 = array.Length -> array
        | Some n -> Array.take (n + 1) array
