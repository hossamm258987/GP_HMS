using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface IHospitalRepository
    {
        Task<List<HospitalDTO>> Get_Hospitals();
        Task<HospitalDTO> Get_Hospital_By_Id(int id);
        Task<List<HospitalDTO>> Get_Hospital_By_Name(string name);
        Task<HospitalDTO> Create_Update_Hospital(HospitalDTO hospitalDto);
        Task<bool> Delete_Hospital_By_Id(int id);
    }
}
