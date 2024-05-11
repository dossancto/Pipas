namespace Pipas;

public static class PipaVoidExtension
{
    /// <summary>
    /// Executes the provided function, but return the input as output.
    /// Used when want to apply a method that does not returns a value
    /// </summary>
    public static TIn PipaVoid
      <TIn>

      (this TIn input,
       Action<TIn> fn)
    {
        fn(input);

        return input;
    }

    /// <summary>
    /// Executes the provided function, but return the input as output.
    /// Used when want to apply a method that does not returns a value. (Task)
    /// </summary>
    public static async Task<TIn> PipaTask
      <TIn, TOut>(
          this Task<TIn> input,
          Func<TIn, TOut> fn
       )
    {
        var a = await input;

        fn(a);

        return a;
    }

}
