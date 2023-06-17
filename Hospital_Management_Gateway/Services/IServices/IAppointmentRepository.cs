using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IAppointmentRepository
    {
        Task<T> Get_Appointments<T>();
        Task<T> Get_Appointment_By_Id<T>(int id);
        Task<T> Get_Appointment_By_Name<T>(string name);
        Task<T> Get_Appointment_By_Number<T>(int number, DateTime time);
        Task<T> Get_Appointment_By_Patient<T>(int pid);
        Task<T> Get_Appointment_By_Section<T>(int sid);
        Task<T> Get_Appointment_By_Section<T>(int sid, DateTime time);
        Task<T> Create_Appointment<T>(AppointmentDTO appointmentDto);
        Task<T> Update_Appointment<T>(AppointmentDTO appointmentDto);
        Task<T> Delete_Appointment_By_Id<T>(int id);
    }
}
