namespace Pipas;

public static class PipaTupleExtension
{
    /// <summary>
    /// Return the input of this function, and the function return.
    /// Eg. If the function param is `string` and the function return type is `int`, 
    /// the return will be (`string`, `int`)
    /// </summary>
    public static (TOut Output, TIn Input) PipaTuple<TIn, TOut>
      (
       this TIn input,
       Func<TIn, TOut> fn
       )
      => (fn(input), input);

    public static (TOut Output, TIn Input) PipaTuple<TIn, TParam1, TOut>
      (this TIn input, Func<TIn, TParam1, TOut> fn, TParam1 p1)
      => (fn(input, p1), input);

    public static async Task<(TOut Output, TIn Input)> PipaTupleAsync
      <TIn, TParam1, TOut>

      (this Task<TIn> input,
       Func<TIn, TParam1, TOut> fn, TParam1 p1)
    {
        var a = await input;

        return (fn(a, p1), a);
    }

    public static async Task<(TOut Output, TIn Input)> PipaTupleAsync
      <TIn, TOut>

      (this Task<TIn> input,
       Func<TIn, TOut> fn)
    {
        var inputResult = await input;

        return (fn(inputResult), inputResult);
    }

    public static async Task<(TOut Output, TIn Input)> PipaTupleAsync
      <TIn, TOut>

      (this Task<TIn> input,
       Func<TIn, Task<TOut>> fn)
    {
        var inputResult = await input;

        return (await fn(inputResult), inputResult);
    }

    public static async Task<(TOut Output, TIn Input)> PipaTupleAwait
      <TIn, TIn2, TOut>(
       this (Task<TIn> a, TIn2 b) input,
       Func<TIn, TIn2, Task<TOut>> fn
       )
    {
        var inputResult = await input.a;

        return (await fn(inputResult, input.b), inputResult);
    }

    /// <summary>
    /// Receives the input as Tuple, then resolve the first paramether with `await`,
    /// then return the function result with the used input.
    /// </summary>
    /// <returns>The provided `Input` and the function `Output`</returns>
    public static async Task<(TOut Output, TIn Input)> PipaTupleAwait
      <TIn, TIn2, TOut>(
       this (Task<TIn> a, TIn2 b) input,
       Func<TIn, TIn2, TOut> fn
       )
    {
        var inputResult = await input.a;

        return (fn(inputResult, input.b), inputResult);
    }

    /// <summary>
    /// Receives the input as Tuple, then resolve the **first** paramether with `await`,
    /// then return the function result.
    /// </summary>
    /// <returns>The function `Output`</returns>
    public static async Task<TOut> PipaAwait
      <TIn, TIn2, TOut>(
       this (Task<TIn> a, TIn2 b) input,
       Func<TIn, TIn2, TOut> fn
       )
    {
        var inputResult = await input.a;

        return fn(inputResult, input.b);
    }

    /// <summary>
    /// Receives the input as Tuple, then resolve the **secound** paramether with `await`,
    /// then return the function result.
    /// </summary>
    /// <returns>The function `Output`</returns>
    public static async Task<TOut> PipaAwait
      <TIn, TIn2, TOut>(
       this (TIn a, Task<TIn2> b) input,
       Func<TIn, TIn2, TOut> fn
       )
    {
        var aInput = input.a;
        var bInput = await input.b;

        return fn(aInput, bInput);
    }

    /// <summary>
    /// Receives the input as Tuple, then resolve the **BOTH** paramether with `await`,
    /// then return the function result.
    /// </summary>
    /// <returns>The function `Output`</returns>
    public static async Task<TOut> PipaAwait
      <TIn, TIn2, TOut>(
       this (Task<TIn> a, Task<TIn2> b) input,
       Func<TIn, TIn2, TOut> fn
       )
    {
        var aInput = await input.a;
        var bInput = await input.b;

        return fn(aInput, bInput);
    }
}
