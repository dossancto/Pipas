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
        await Task.Delay(50);

        return "some-id";
    }

    private Task PrintSomething(User u)
    {
        /// ... logs something, or apply any changes without return type
        return Task.CompletedTask;
    }

    private void ValidateUser(User u)
    {
        /// ... Apply some user validation
    }

    [Fact]
    public async Task Example_1()
    {
        var payload = new User { Name = "  John   " };

        var formatUserName = (User p) => p with { Name = p.Name.Trim() };

        var result = await payload

          /*
           * Does not returns nothing, so keep
           * the input value to next pipe 
          */
          .PipaVoid(ValidateUser)

          /*
           * returns the formated user values
          */
          .Pipa(formatUserName)

          /*
           * Return a tuple with the suplied values (Output, Input)
           * In this case, (Task<String> Id, User user)
          */
          .PipaTuple(SaveUserInDatabase)

          /*
           * Resolves the async Task<string> to can be used without await
           * Maps the tuple for apply some rule.
           * Returns only the Output
          */
          .PipaAwait((string id, User user) => user with { Id = id })

          /*
           * Logs the result, this function return type is Task, so we keep the input value as Output
          */
          .PipaTask(PrintSomething)
          ;

        result.Id.Should().Be("some-id");
        result.Name.Should().Be("John");
    }
}

