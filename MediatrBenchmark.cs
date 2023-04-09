namespace MediatrPerformance;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

[MemoryDiagnoser]
public class MediatrBenchmark
{
    private readonly IMediator _mediator;
    private readonly ExampleService _exampleService = new();
    public MediatrBenchmark()
    {
        var services = new ServiceCollection();
        var serviceProvider = services.BuildServiceProvider();
        _mediator = serviceProvider!.GetRequiredService<IMediator>();
    }

    [Benchmark]
    public async Task<int> Mediatr()
    {
        var request = new ExampleRequest { Number = 69 };
        return await _mediator.Send(request);
    }

    [Benchmark]
    public async Task<int> Direct()
    {
        return await _exampleService.Handle(69);
    }
}