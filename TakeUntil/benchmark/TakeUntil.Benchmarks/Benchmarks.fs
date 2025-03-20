namespace TakeUntil

open BenchmarkDotNet.Attributes

[<MemoryDiagnoser>]
type Benchmarks() =

    let sequence = seq { 1..1000 }
    let list = [ 1..1000 ]
    let array = [| 1..1000 |]

    [<Benchmark>]
    member _.Seq_TakeUntil_0() =
        sequence |> Seq.takeUntil (fun x -> x = 0) |> Seq.last |> ignore

    [<Benchmark>]
    member _.Seq_TakeUntil_1000() =
        sequence |> Seq.takeUntil (fun x -> x = 1000) |> Seq.last |> ignore

    [<Benchmark>]
    member _.Seq_TakeUntil_500() =
        sequence |> Seq.takeUntil (fun x -> x = 500) |> Seq.last |> ignore

    [<Benchmark>]
    member _.Seq_TakeUntil_1() =
        sequence |> Seq.takeUntil (fun x -> x = 1) |> Seq.last |> ignore

    [<Benchmark>]
    member _.List_TakeUntil_0() =
        list |> List.takeUntil (fun x -> x = 0) |> ignore

    [<Benchmark>]
    member _.List_TakeUntil_1000() =
        list |> List.takeUntil (fun x -> x = 1000) |> ignore

    [<Benchmark>]
    member _.List_TakeUntil_500() =
        list |> List.takeUntil (fun x -> x = 500) |> ignore

    [<Benchmark>]
    member _.List_TakeUntil_1() =
        list |> List.takeUntil (fun x -> x = 1) |> ignore

    [<Benchmark>]
    member _.Array_TakeUntil_0() =
        array |> Array.takeUntil (fun x -> x = 0) |> ignore

    [<Benchmark>]
    member _.Array_TakeUntil_1000() =
        array |> Array.takeUntil (fun x -> x = 1000) |> ignore

    [<Benchmark>]
    member _.Array_TakeUntil_500() =
        array |> Array.takeUntil (fun x -> x = 500) |> ignore

    [<Benchmark>]
    member _.Array_TakeUntil_1() =
        array |> Array.takeUntil (fun x -> x = 1) |> ignore
