using MediatR;

namespace MediatrPerformance;

public class ExampleRequest : IRequest<int>
{
    public int Number { get; set; }
}