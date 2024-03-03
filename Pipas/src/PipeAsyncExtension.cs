namespace Pipas;

public static class PipaAsyncExtension
{
    public static async Task<TOut> Pipa
      <TIn, TParam1, TOut>

      (this Task<TIn> input,
       Func<TIn, TParam1, TOut> fn, TParam1 p1)
    {
        var a = await input;
        return fn(a, p1);
    }

    public static async Task<TOut> Pipa
      <TIn, TOut>

      (this Task<TIn> input,
       Func<TIn, TOut> fn)
    {
        var a = await input;
        return fn(a);
    }

    public static TOut Pipa2
      <TIn, TOut>

      (this TIn input,
       Func<TIn, TOut> fn)
    {
        var a = input;
        return fn(a);
    }

    public static async Task<TOut> Pipa<TIn, TOut>
      (this TIn input, Func<TIn, Task<TOut>> fn)
      => await fn(input);
}
