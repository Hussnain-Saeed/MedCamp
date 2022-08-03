using Microsoft.EntityFrameworkCore;

namespace MedCamp.Models
{
    public class MedCampContext:DbContext
    {
        public MedCampContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Global turn off delete behaviour on foreign keys
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<ConsultationStatus> ConsultationStatuses { get; set; }
        public DbSet<DoctorDetail> DoctorDetails { get; set; }
        public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
