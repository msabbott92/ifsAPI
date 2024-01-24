namespace TherapyApi.Models
{
    public class Patient
    {
        public long Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Pronouns { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Part> Parts { get; set; } = new List<Part>();
        public string? Secret { get; set; }
    }
}
