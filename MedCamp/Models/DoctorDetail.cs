namespace MedCamp.Models
{
    public class DoctorDetail
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Fee { get; set; }
        public virtual User Doctor { get; set; }
        public int DoctorId { get; set; }
    }
}
