## F# implementation of a ```takeUntil``` function [![Nuget Version](https://img.shields.io/nuget/v/TakeUntil)](https://www.nuget.org/packages/TakeUntil)

Returns a collection that contains all elements of the original collection
until the given predicate returns ```True```, and then returns no further elements.

### Getting started

Import ```TakeUntil``` namespace

```fsharp
open TakeUntil
```

### Seq Module

```fsharp
let inputs = seq { "a"; "bb"; "ccc"; "d" }

inputs |> Seq.takeUntil (fun x -> x.Length = 3)
```

Evaluates to a sequence yielding the same results as

```fsharp
seq { "a"; "bb"; "ccc" }
```

### List Module

```fsharp
let inputs = [ "a"; "bb"; "ccc"; "d" ]

inputs |> List.takeUntil (fun x -> x.Length = 3)
```

Evaluates to

```fsharp
[ "a"; "bb"; "ccc" ]
```

### Array Module

```fsharp
let inputs = [| "a"; "bb"; "ccc"; "d" |]

inputs |> Array.takeUntil (fun x -> x.Length = 3)
```

Evaluates to

```fsharp
[| "a"; "bb"; "ccc" |]
```