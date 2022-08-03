namespace MedCamp.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Fee { get; set; }
        public virtual User Doctor { get; set; }
        public int DoctorId { get; set; }
        public virtual User Patient { get; set; }
        public int PatientId { get; set; }
        public virtual ConsultationStatus ConsultationStatus { get; set; }
        public int ConsultationStatusId { get; set; }
    }
}
