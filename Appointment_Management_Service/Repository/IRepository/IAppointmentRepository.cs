using Appointment_Management_Service.Models.DTOs;

namespace Appointment_Management_Service.Repository.IRepository
{
    public interface IAppointmentRepository
    {
        Task<List<AppointmentDTO>> Get_Appointments();
        Task<AppointmentDTO> Get_Appointment_By_Id(int id);
        Task<List<AppointmentDTO>> Get_Appointment_By_Name(string name);
        Task<List<AppointmentDTO>> Get_Appointment_By_Number(int number, DateTime time);
        Task<List<AppointmentDTO>> Get_Appointment_By_Patient(int pid);
        Task<List<AppointmentDTO>> Get_Appointment_By_Section(int sid);
        Task<List<AppointmentDTO>> Get_Appointment_By_Section(int sid, DateTime time);
        Task<AppointmentDTO> Create_Update_Appointment(AppointmentDTO appointmentDto);
        Task<bool> Delete_Appointment_By_Id(int id);
    }
}
