namespace Pipas;

public static class AsyncTuplePipa
{
    public static async Task<(TOut Output, TIn Input)> Pipa
      <TIn, TOut>

      (this (Task<TIn>, TOut) input,
       Func<(TIn Output, TOut Input), TOut> fn)
    {
        var a1 = await input.Item1;

        var fnResult = fn((a1, input.Item2));

        return (fnResult, a1);
    }

    public static async Task<(TOut Output, TIn Input)> Pipa
      <TIn, TOut>

      (this (Task<TIn>, TOut) input,
       Func<(Task<TIn> Output, TOut Input), TOut> fn)
    {
        var a1 = input.Item1;

        var fnResult = fn((a1, input.Item2));

        return (fnResult, await a1);
    }

    public static async Task<TOut> TupleOutput
      <TIn, TOut>

      (this Task<(TIn, TOut)> input)
    => (await input).Item2;

    public static async Task<TIn> TupleInput
      <TIn, TOut>

      (this Task<(TIn, TOut)> input)
    => (await input).Item1;
}
