using Microsoft.EntityFrameworkCore;

namespace TherapyApi.Models
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Part> Parts { get; set; }
        public DbSet<CustomQuestion> CustomQuestions { get; set; }
    }
}
