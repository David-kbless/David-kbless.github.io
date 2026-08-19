using Portfolio.Models;

namespace Portfolio.Services;

public interface IProjectService
{
    Task<IReadOnlyList<Project>> GetProjectsAsync(CancellationToken cancellationToken = default);
}
