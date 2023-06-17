namespace Appointment_Management_Service.Models
{
    public class Doctor : Staff
    {
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
