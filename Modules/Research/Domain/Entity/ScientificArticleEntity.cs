namespace AttendanceEpiisBk.Modules.Research.Domain.Entity;

public record ScientificArticleEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Doi { get; set; } = string.Empty;
    public string Authors { get; set; } = string.Empty;
    public string Pdf { get; set; } = string.Empty;
    public int IdNivel { get; set; }
    public string Editor { get; set; } = string.Empty;
}