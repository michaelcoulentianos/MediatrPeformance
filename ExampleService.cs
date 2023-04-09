public class ExampleService
{
    public async Task<int> Handle(int number)
    {
        return await Task.FromResult(420 + number);
    }
}