namespace Portfolio.Models;

public sealed class Certification
{
    public string Title { get; set; } = "";
    public string Issuer { get; set; } = "";
    public string Date { get; set; } = "";
    public string Description { get; set; } = "";
    public List<string> SkillsAcquired { get; set; } = [];
    public string CertificateUrl { get; set; } = "";
    public string CredentialId { get; set; } = "";
    public string CredentialUrl { get; set; } = "";
}
