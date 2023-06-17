namespace Appointment_Management_Service.Models.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int DocMETimeId { get; set; }
        public DocMETimeDTO DocMETimeDto { get; set; }
        public double Price { get; set; }
        public double Pay { get; set; }
        public double NPrice
        {
            get
            {
                return Price - Pay;
            }
        }
        public bool Status { get; set; }
        public DateTime AppointTime { get; set; }
        public int patientId { get; set; }
        public PatientDTO PatientDto { get; set; }
        public bool IsActive { get; set; }
    }
}
