using System.Net.Http.Json;
using Portfolio.Models;

namespace Portfolio.Services;

public sealed class ProjectService(HttpClient httpClient) : IProjectService
{
    public async Task<IReadOnlyList<Project>> GetProjectsAsync(CancellationToken cancellationToken = default)
    {
        var projects = await httpClient.GetFromJsonAsync<List<Project>>("data/projects.json", cancellationToken);
        return projects ?? [];
    }
}
