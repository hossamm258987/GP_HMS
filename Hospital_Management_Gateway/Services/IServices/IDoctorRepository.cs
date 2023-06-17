using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IDoctorRepository
    {
        Task<T> Get_Doctors<T>();
        Task<T> Get_Doctor_By_Id<T>(int id);
        Task<T> Get_Doctor_By_Name<T>(string name);
        Task<T> Get_Doctor_By_Specialization<T>(int specId);
        Task<T> Create_Doctor<T>(DoctorDTO doctorDto);
        Task<T> Update_Doctor<T>(DoctorDTO doctorDto);
        Task<T> Delete_Doctor_By_Id<T>(int id);
    }
}
