namespace Portfolio.Models;

public sealed class Project
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Technologies { get; set; } = "";
    public string GitHubUrl { get; set; } = "";
    public List<ProjectImage> Images { get; set; } = [];
    public List<string> SkillsAcquired { get; set; } = [];
    public List<ProjectSection> Sections { get; set; } = [];
}

public sealed class ProjectImage
{
    public string Url { get; set; } = "";
    public string Alt { get; set; } = "";
    public string Caption { get; set; } = "";
}
