namespace MedCamp.Models.ViewModels
{
    public class DoctorInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Fee { get; set; }
        public List<string> Speciality { get; set; } = new List<string>();
    }
}
