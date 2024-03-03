namespace Pipas;

public static class PipaTupleExtension
{
    public static (TOut Output, TIn Input) PipaTuple<TIn, TOut>
      (this TIn input, Func<TIn, TOut> fn)
      => (fn(input), input);

    public static async Task<(TOut Output, TIn Input)> PipaTuple<TIn, TOut>
      (this Task<TIn> input, Func<TIn, TOut> fn)
    {
        var val = await input;
        return (fn(val), val);
    }

    public static (TOut Output, TIn Input) PipaTuple<TIn, TParam1, TOut>
      (this TIn input, Func<TIn, TParam1, TOut> fn, TParam1 p1)
      => (fn(input, p1), input);

    public static async Task<(TOut Output, TIn Input)> PipaTuple
      <TIn, TParam1, TOut>

      (this Task<TIn> input,
       Func<TIn, TParam1, TOut> fn, TParam1 p1)
    {
        var a = await input;

        return (fn(a, p1), a);
    }

    // public static async Task<(TOut Output, TIn Input)> PipaTuple
    //   <TIn, TOut>

    //   (this Task<TIn> input,
    //    Func<TIn, TOut> fn)
    // {
    //     var inputResult = await input;

    //     return (fn(inputResult), inputResult);
    // }

    public static async Task<(TOut Output, TIn Input)> PipaTuple
      <TIn, TOut>

      (this Task<TIn> input,
       Func<TIn, Task<TOut>> fn)
    {
        var inputResult = await input;

        return (await fn(inputResult), inputResult);
    }
}
