namespace TakeUntil

module Seq =

    let inline checkNonNull (argName: string) (arg: 'T) : unit =
        if isNull arg then
            nullArg argName

    [<CompiledName("TakeUntil")>]
    let takeUntil (predicate: 'T -> bool) (source: 'T seq) : 'T seq =
        checkNonNull "source" source

        seq {
            use e = source.GetEnumerator()

            let mutable current = Unchecked.defaultof<_>
            let mutable ok = true

            while ok && e.MoveNext() do
                current <- e.Current
                ok <- not <| predicate current
                yield current
        }

module List =

    [<CompiledName("TakeUntil")>]
    let takeUntil (predicate: 'T -> bool) (list: 'T list) : 'T list =
        match list |> List.tryFindIndex predicate with
        | None -> list
        | Some ix -> list |> List.take (ix + 1)

module Array =

    [<CompiledName("TakeUntil")>]
    let takeUntil (predicate: 'T -> bool) (array: 'T array) : 'T array =
        match array |> Array.tryFindIndex predicate with
        | None -> array
        | Some ix -> array |> Array.take (ix + 1)
