﻿using System.Net;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace Gateway.Api;

public class CombineProductDetailsAggregator : IDefinedAggregator
{
    public async Task<DownstreamResponse> Aggregate(List<HttpContext> responseContexts)
    {
        var responses = responseContexts.Select(x => x.Items.DownstreamResponse()).ToArray();

        // In this example we are concatenating the results,
        // but you could create a more complex construct, up to you.
        var contentList = new List<string>();
        foreach (var response in responses)
        {
            var content = await response.Content.ReadAsStringAsync();
            contentList.Add(content);
        }

        // The only constraint here: You must return a DownstreamResponse object.
        return new DownstreamResponse(
            new StringContent(JsonConvert.SerializeObject(contentList)),
            HttpStatusCode.OK,
            responses.SelectMany(x => x.Headers).ToList(),
            "reason");
    }
}
