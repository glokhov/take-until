module TakeUntilTests

open System
open FsCheck.Xunit
open FsUnit.Xunit
open FsUnitTyped
open TakeUntil
open Xunit

let even (x: int) : bool = x % 2 = 0
let zero (x: int) : bool = x = 0
let one (x: int) : bool = x = 1
let five (x: int) : bool = x = 5
let ten (x: int) : bool = x = 10

[<Fact>]
let ``if a sequence is null takeUntil throws an ArgumentNullException`` () =
    (fun () -> Seq.takeUntil even null |> ignore) |> should throw typeof<ArgumentNullException>

[<Fact>]
let ``if a sequence is empty takeUntil returns an empty sequence`` () =
    Seq.empty |> Seq.takeUntil zero |> shouldBeEmpty

[<Fact>]
let ``if a sequence has no matching elements takeUntil returns the full sequence`` () =
    seq { 1..10 } |> Seq.takeUntil zero |> Seq.toList |> should equal [ 1..10 ]

[<Fact>]
let ``if a sequence has matching element at the end takeUntil returns the full sequence`` () =
    seq { 1..10 } |> Seq.takeUntil ten |> Seq.toList |> should equal [ 1..10 ]

[<Fact>]
let ``if a sequence has matching element in the middle takeUntil returns a sequence including matching element`` () =
    seq { 1..10 } |> Seq.takeUntil five |> Seq.toList |> should equal [ 1..5 ]

[<Fact>]
let ``if a sequence has matching element at the start takeUntil returns the fist element`` () =
    seq { 1..10 } |> Seq.takeUntil one |> Seq.toList |> should equal [ 1 ]

[<Fact>]
let ``predicate is not called more than necessary (sequence)`` () =
    let mutable counts = 0
    Seq.singleton 1 |> Seq.takeUntil (fun _ -> counts <- counts + 1; true) |> Seq.head |> should equal 1
    counts |> should equal 0

[<Fact>]
let ``if a list is empty takeUntil returns an empty list`` () =
    List.empty |> List.takeUntil zero |> shouldBeEmpty

[<Fact>]
let ``if a list has no matching elements takeUntil returns the full list`` () =
    [ 1..10 ] |> List.takeUntil zero |> should equal [ 1..10 ]

[<Fact>]
let ``if a list has matching element at the end takeUntil returns the full list`` () =
    [ 1..10 ] |> List.takeUntil ten |> should equal [ 1..10 ]

[<Fact>]
let ``if a list has matching element in the middle takeUntil returns a list including matching element`` () =
    [ 1..10 ] |> List.takeUntil five |> should equal [ 1..5 ]

[<Fact>]
let ``if a list has matching element at the start takeUntil returns the fist element`` () =
    [ 1..10 ] |> List.takeUntil one |> should equal [ 1 ]

[<Fact>]
let ``if an array is empty takeUntil returns an empty array`` () =
    Array.empty |> Array.takeUntil zero |> shouldBeEmpty

[<Fact>]
let ``if an array has no matching elements takeUntil returns the full array`` () =
    [| 1..10 |] |> Array.takeUntil zero |> should equal [| 1..10 |]

[<Fact>]
let ``if an array has matching element at the end takeUntil returns the full array`` () =
    [| 1..10 |] |> Array.takeUntil ten |> should equal [| 1..10 |]

[<Fact>]
let ``if an array has matching element in the middle takeUntil returns an array including matching element`` () =
    [| 1..10 |] |> Array.takeUntil five |> should equal [| 1..5 |]

[<Fact>]
let ``if an array has matching element at the start takeUntil returns the fist element`` () =
    [| 1..10 |] |> Array.takeUntil one |> should equal [| 1 |]

[<Property>]
let ``property-based test: sequence agrees with list model`` (xs: int list) =
    xs |> Seq.takeUntil even |> Seq.toList |> (=) (List.takeUntil even xs)

[<Property>]
let ``property-based test: sequence agrees with array model`` (xs: FsCheck.NonNull<int[]>) =
    let xs = xs.Get
    xs |> Seq.takeUntil even |> Seq.toArray |> (=) (Array.takeUntil even xs)
