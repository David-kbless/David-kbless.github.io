namespace Portfolio.Models;

public sealed class ProjectBullet
{
    public string Text { get; set; } = "";
    public List<string> SubItems { get; set; } = [];
}

public sealed class ProjectSection
{
    public string Title { get; set; } = "";
    public string Subtitle { get; set; } = "";
    public List<ProjectBullet> Items { get; set; } = [];
}
