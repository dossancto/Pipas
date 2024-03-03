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

    [Fact]
    public async Task Example_1()
    {
        var payload = new User { Name = "  John   " };

        var applyIdToUser = ((string id, User user) p) => p.user with { Id = p.id };

        var formatUserName = (User p) => p with { Name = p.Name.Trim() };

        var result = await payload
          .Pipa(formatUserName)
          .PipaTuple(SaveUserInDatabase)
          .Pipa(applyIdToUser).TupleInput()
          ;

        result.Id.Should().Be("some-id");
        result.Name.Should().Be("John");
    }
}

