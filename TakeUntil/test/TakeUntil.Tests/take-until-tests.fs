module TakeUntil.Tests

open System
open TakeUntil
open Xunit

[<Fact>]
let ``if sequence is null takeUntil throws an ArgumentNullException`` () =
    Assert.Throws<ArgumentNullException>(fun _ -> null |> Seq.takeUntil (fun _ -> true) |> ignore)

[<Fact>]
let ``if a sequence is empty takeUntil returns an empty sequence`` () =
    let sequence = Seq.empty |> Seq.takeUntil (fun x -> x = 0)
    Assert.Empty sequence

[<Fact>]
let ``if a sequence has no matching elements takeUntil returns the full sequence`` () =
    let sequence = seq { 1..10 } |> Seq.takeUntil (fun x -> x = 0) |> List.ofSeq
    Assert.True([ 1..10 ] = sequence)

[<Fact>]
let ``if a sequence has matching element at the end takeUntil returns the full sequence`` () =
    let sequence = seq { 1..10 } |> Seq.takeUntil (fun x -> x = 10) |> List.ofSeq
    Assert.True([ 1..10 ] = sequence)

[<Fact>]
let ``if a sequence has matching element in the middle takeUntil returns a sequence including matching element`` () =
    let sequence = seq { 1..10 } |> Seq.takeUntil (fun x -> x = 5) |> List.ofSeq
    Assert.True([ 1..5 ] = sequence)

[<Fact>]
let ``if a sequence has matching element at the start takeUntil returns the fist element`` () =
    let sequence = seq { 1..10 } |> Seq.takeUntil (fun x -> x = 1) |> List.ofSeq
    Assert.True([ 1 ] = sequence)

[<Fact>]
let ``if a list is empty takeUntil returns an empty list`` () =
    let list = List.empty |> List.takeUntil (fun x -> x = 0)
    Assert.Empty list

[<Fact>]
let ``if a list has no matching elements takeUntil returns the full list`` () =
    let list = [ 1..10 ] |> List.takeUntil (fun x -> x = 0)
    Assert.True([ 1..10 ] = list)

[<Fact>]
let ``if a list has matching element at the end takeUntil returns the full list`` () =
    let list = [ 1..10 ] |> List.takeUntil (fun x -> x = 10)
    Assert.True([ 1..10 ] = list)

[<Fact>]
let ``if a list has matching element in the middle takeUntil returns a list including matching element`` () =
    let list = [ 1..10 ] |> List.takeUntil (fun x -> x = 5)
    Assert.True([ 1..5 ] = list)

[<Fact>]
let ``if a list has matching element at the start takeUntil returns the fist element`` () =
    let list = [ 1..10 ] |> List.takeUntil (fun x -> x = 1)
    Assert.True([ 1 ] = list)

[<Fact>]
let ``if an array is empty takeUntil returns an empty array`` () =
    let array = Array.empty |> Array.takeUntil (fun x -> x = 0)
    Assert.Empty array

[<Fact>]
let ``if an array has no matching elements takeUntil returns the full array`` () =
    let array = [| 1..10 |] |> Array.takeUntil (fun x -> x = 0)
    Assert.True([| 1..10 |] = array)

[<Fact>]
let ``if an array has matching element at the end takeUntil returns the full array`` () =
    let array = [| 1..10 |] |> Array.takeUntil (fun x -> x = 10)
    Assert.True([| 1..10 |] = array)

[<Fact>]
let ``if an array has matching element in the middle takeUntil returns an array including matching element`` () =
    let array = [| 1..10 |] |> Array.takeUntil (fun x -> x = 5)
    Assert.True([| 1..5 |] = array)

[<Fact>]
let ``if an array has matching element at the start takeUntil returns the fist element`` () =
    let array = [| 1..10 |] |> Array.takeUntil (fun x -> x = 1)
    Assert.True([| 1 |] = array)

[<Fact>]
let ``property-based test: sequence agrees with list model`` () =
    let pred (x : int) = x % 2 = 0
    let property (xs : int list) =
        xs
        |> Seq.takeUntil pred
        |> Seq.toList
        |> (=) (List.takeUntil pred xs)

    FsCheck.Check.QuickThrowOnFailure property

[<Fact>]
let ``property-based test: sequence agrees with array model`` () =
    let pred (x : int) = x % 2 = 0
    let property (xs : FsCheck.NonNull<int[]>) =
        let xs = xs.Get
        xs
        |> Seq.takeUntil pred
        |> Seq.toArray
        |> (=) (Array.takeUntil pred xs)

    FsCheck.Check.QuickThrowOnFailure property
