namespace Pipas.Test;

public record User
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class AsyncUsage
{
    private async Task<string> SaveUserInDatabase(User user)
    {
        await Task.Delay(1000);

        return "some-id";
    }

    private Task PrintSomething(User u)
    {
        /// ... logs something, or apply any changes without return type
        return Task.CompletedTask;
    }

    [Fact]
    public async Task Example_1()
    {
        var payload = new User { Name = "  John   " };

        var formatUserName = (User p) => p with { Name = p.Name.Trim() };

        var result = await payload
          .Pipa(formatUserName)
          .PipaTuple(SaveUserInDatabase)
          .PipaAwait((id, user) => user with { Id = id })
          .PipaTask(PrintSomething)
          ;

        result.Id.Should().Be("some-id");
        result.Name.Should().Be("John");
    }
}

