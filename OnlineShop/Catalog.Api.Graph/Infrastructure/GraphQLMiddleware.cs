using System.Net;
using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.Transport;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace Catalog.Api.Graph.Infrastructure;

public class GraphQLMiddleware : IMiddleware
{
    private readonly GraphQLSettings _settings;
    private readonly IDocumentExecuter<ISchema> _executor;
    private readonly IGraphQLSerializer _serializer;

    public GraphQLMiddleware(
        GraphQLSettings settings,
        IDocumentExecuter<ISchema> executor,
        IGraphQLSerializer serializer)
    {
        _settings = settings;
        _executor = executor;
        _serializer = serializer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!IsGraphQLRequest(context))
        {
            await next(context);
            return;
        }

        await ExecuteAsync(context);
    }

    private bool IsGraphQLRequest(HttpContext context)
    {
        return context.Request.Path.StartsWithSegments(_settings.Path)
            && string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase);
    }

    private async Task ExecuteAsync(HttpContext context)
    {
        var request = await _serializer.ReadAsync<GraphQLRequest>(context.Request.Body, context.RequestAborted);

        var start = DateTime.UtcNow;

        var result = await _executor.ExecuteAsync(options =>
        {
            options.Query = request?.Query;
            options.OperationName = request?.OperationName;
            options.Variables = request?.Variables;
            options.UserContext = _settings.BuildUserContext?.Invoke(context);
            options.EnableMetrics = _settings.EnableMetrics;
            options.RequestServices = context.RequestServices;
            options.CancellationToken = context.RequestAborted;
            options.User = context.User;
        });

        if (_settings.EnableMetrics)
        {
            result.EnrichWithApolloTracing(start);
        }

        await WriteResponseAsync(context, result);
    }

    private async Task WriteResponseAsync(HttpContext context, ExecutionResult result)
    {
        context.Response.ContentType = "application/graphql+json";
        context.Response.StatusCode = result.Executed ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;

        await _serializer.WriteAsync(context.Response.Body, result, context.RequestAborted);
    }
}
