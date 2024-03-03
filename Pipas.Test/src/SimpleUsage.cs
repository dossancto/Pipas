namespace Pipas.Test;

public class SimpleUsage
{
    [Fact]
    public void Example_1()
    {
        var add = (int a, int b) => a + b;
        var square = (int a) => a * a;

        var result = 5
          .Pipa(add, 5)
          .Pipa(square)
          ;

        result.Should().Be(100);
    }
}
