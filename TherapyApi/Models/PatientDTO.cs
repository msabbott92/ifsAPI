namespace TherapyApi.Models
{
    public class PatientDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Pronouns { get; set; }
        public bool IsActive { get; set; }
    }
}
