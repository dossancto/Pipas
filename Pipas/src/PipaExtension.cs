namespace Pipas;

public static partial class PipaExtension
{
    public static TOut Pipa<TIn, TOut>
      (this TIn input, Func<TIn, TOut> fn)
      => fn(input);

    public static TOut Pipa<TIn, TParam1, TOut>
      (this TIn input, Func<TIn, TParam1, TOut> fn, TParam1 p1)
      => fn(input, p1);
}

