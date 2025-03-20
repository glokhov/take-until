open BenchmarkDotNet.Running
open TakeUntil

BenchmarkRunner.Run<Benchmarks>() |> ignore