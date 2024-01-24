namespace TherapyApi.Models;
public class PartDTO
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }

    // Standard questions
    public string? QuestionFind { get; set; }
    public string? QuestionFocus { get; set; }
    public string? QuestionFlesh { get; set; }
    public string? QuestionFeel { get; set; }
    public string? QuestionFriend { get; set; }
    public string? QuestionFears { get; set; }

}
