using BenchmarkDotNet.Running;
using MediatrPerformance;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRequestHandler<ExampleRequest, int>, ExampleHandler>();

builder.Services.AddTransient<ExampleService>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();
BenchmarkRunner.Run<MediatrBenchmark>();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
    });
    app.UseDeveloperExceptionPage();
}
app.UseRouting();


app.MapGet("/mediatr/{num}", async (int num) =>
{
    var request = new ExampleRequest { Number = num };
    // Resolve MediatR and send a request

    var mediator = app.Services.GetRequiredService<IMediator>();
    var result = await mediator.Send(request);
    // Logic to handle GET request
    return Results.Ok(result);
});

app.MapGet("/service/{num}", async (int num) =>
{
    var result = await new ExampleService().Handle(num);
    // Logic to handle GET request
    return Results.Ok(result);
});


app.Run();
