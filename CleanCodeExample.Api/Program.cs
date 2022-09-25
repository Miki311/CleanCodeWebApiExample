using CleanCodeExample.Api;
using CleanCodeExample.Api.Common.Errors;
using CleanCodeExample.Api.Filters;
using CleanCodeExample.Api.Middleware;
using CleanCodeExample.Application;
using CleanCodeExample.Application.Services.Authentication;
using CleanCodeExample.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration);

//builder.Services.AddMediatR(typeof(Program));

//1. Register Error handlig filter
//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

builder.Services.AddControllers();

//3. Register Custom Error handlig using ProblemDetailsFactory, extending the Problem/ProblemDetails
builder.Services.AddSingleton<ProblemDetailsFactory, CleanCodeProblemDetailsFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register MediatR services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

//2. register error hadnling middleware
//app.UseMiddleware<ErrorHandlingMiddleware>(); 

//4. Use error endpoint
app.UseExceptionHandler("/error");

//5. minimal api error handling approach
//app.Map("/error", (HttpContext httpContext) =>
//{
//    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

//    return Results.Problem();
//});

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
