namespace MedCamp.Models
{
    public class DoctorSpeciality
    {
        public int Id { get; set; }
        public virtual User Doctor { get; set; }
        public int DoctorId { get; set; }
        public virtual Speciality Speciality { get; set; }
        public int SpecialityId { get; set; }

    }
}
