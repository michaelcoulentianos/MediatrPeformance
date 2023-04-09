using MediatR;

namespace MediatrPerformance;

public class ExampleHandler : IRequestHandler<ExampleRequest, int>
{
    public Task<int> Handle(ExampleRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(420 + request.Number);
    }
}