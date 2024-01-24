namespace TherapyApi.Models;
public class CustomQuestion
{
    public int Id { get; set; }
    public int PartId { get; set; }
    public Part Part { get; set; }
    public string Question { get; set; }
    public string Response { get; set; }
}
