using System.Net;
using System.Text;
using Portfolio.Services;

namespace Portfolio.Tests;

public sealed class ProjectServiceTests
{
    [Fact]
    public async Task GetProjectsAsync_DeserializesProjects()
    {
        const string json = """
            [{"title":"Pricing engine","description":"Options","technologies":"C#, Blazor","gitHubUrl":"","sections":[]}]
            """;
        var service = CreateService(HttpStatusCode.OK, json);

        var projects = await service.GetProjectsAsync();

        var project = Assert.Single(projects);
        Assert.Equal("Pricing engine", project.Title);
        Assert.Equal("C#, Blazor", project.Technologies);
    }

    [Fact]
    public async Task GetProjectsAsync_ReturnsEmptyListForJsonNull()
    {
        var service = CreateService(HttpStatusCode.OK, "null");

        var projects = await service.GetProjectsAsync();

        Assert.Empty(projects);
    }

    private static ProjectService CreateService(HttpStatusCode statusCode, string content)
    {
        var handler = new StubHandler(new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(content, Encoding.UTF8, "application/json")
        });
        return new ProjectService(new HttpClient(handler) { BaseAddress = new Uri("https://portfolio.test/") });
    }

    private sealed class StubHandler(HttpResponseMessage response) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken) => Task.FromResult(response);
    }
}
