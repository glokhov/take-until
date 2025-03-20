namespace TakeUntil

module Seq =

    /// <summary>Returns a sequence that, when iterated, yields elements of the underlying sequence until the
    /// given predicate returns True, and then returns no further elements.</summary>
    /// <param name="predicate">A function that evaluates to false when no more items should be returned.</param>
    /// <param name="source">The input sequence.</param>
    /// <returns>The result sequence.</returns>
    /// <exception cref="T:System.ArgumentNullException">Thrown when the input sequence is null.</exception>
    /// <example id="take-until-seq">
    /// <code lang="fsharp">
    /// let inputs = seq { "a"; "bb"; "ccc"; "d" }
    /// 
    /// inputs |> Seq.takeUntil (fun x -> x.Length = 3)
    /// </code>
    /// Evaluates to a sequence yielding the same results as <c>seq { "a"; "bb"; "ccc" }</c>
    /// </example>
    [<CompiledName("TakeUntil")>]
    val takeUntil: predicate: ('T -> bool) -> source: 'T seq -> 'T seq

module List =

    /// <summary>Returns a list that contains all elements of the original list until the
    /// given predicate returns True, and then returns no further elements.</summary>
    /// <param name="predicate">A function that evaluates to false when no more items should be returned.</param>
    /// <param name="list">The input list.</param>
    /// <returns>The result list.</returns>
    /// <example id="take-until-list">
    /// <code lang="fsharp">
    /// let inputs = [ "a"; "bb"; "ccc"; "d" ]
    /// 
    /// inputs |> List.takeUntil (fun x -> x.Length = 3)
    /// </code>
    /// Evaluates to <c>[ "a"; "bb"; "ccc" ]</c>
    /// </example>
    [<CompiledName("TakeUntil")>]
    val takeUntil: predicate: ('T -> bool) -> list: 'T list -> 'T list

module Array =

    /// <summary>Returns an array that contains all elements of the original array until the
    /// given predicate returns True, and then returns no further elements.</summary>
    /// <param name="predicate">A function that evaluates to false when no more items should be returned.</param>
    /// <param name="array">The input array.</param>
    /// <returns>The result array.</returns>
    /// <example id="take-until-array">
    /// <code lang="fsharp">
    /// let inputs = [| "a"; "bb"; "ccc"; "d" |]
    /// 
    /// inputs |> Array.takeUntil (fun x -> x.Length = 3)
    /// </code>
    /// Evaluates to <c>[| "a"; "bb"; "ccc" |]</c>
    /// </example>
    [<CompiledName("TakeUntil")>]
    val takeUntil: predicate: ('T -> bool) -> array: 'T array -> 'T array
