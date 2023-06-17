using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface IDoctorRepository
    {
        Task<List<DoctorDTO>> Get_Doctors();
        Task<DoctorDTO> Get_Doctor_By_Id(int id);
        Task<List<DoctorDTO>> Get_Doctor_By_Name(string name);
        Task<List<DoctorDTO>> Get_Doctor_By_Specialization(int specId);
        Task<DoctorDTO> Create_Update_Doctor(DoctorDTO doctorDto);
        Task<bool> Delete_Doctor_By_Id(int id);
    }
}
