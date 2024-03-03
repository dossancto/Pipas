namespace Pipas;

public static class PipaVoidExtension
{
    public static async Task<TIn> Pipa
      <TIn>

      (this TIn input,
       Func<TIn, Task> fn)
    {
        await fn(input);

        return input;
    }

    public static TIn Pipa
      <TIn>

      (this TIn input,
       Action<TIn> fn)
    {
        fn(input);

        return input;
    }

    public static async Task<TIn> Pipa
      <TIn>

      (this Task<TIn> input,
       Action<TIn> fn)
    {
        var val = await input;

        fn(val);

        return val;
    }

    public static async Task PipaVoid
      <TIn>

      (this Task<TIn> input,
       Action<TIn> fn)
    {
        var val = await input;

        fn(val);
    }
}
