namespace UescColcicAPI.Core;

public class Project {

    public int ProjectId { get; set; }
    public required string title { get; set; }
    public required string description { get; set; }
    public required string type { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}