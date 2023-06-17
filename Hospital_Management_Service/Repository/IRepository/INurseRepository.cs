using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface INurseRepository
    {
        Task<List<NurseDTO>> Get_Nurses();
        Task<NurseDTO> Get_Nurse_By_Id(int id);
        Task<List<NurseDTO>> Get_Nurse_By_Name(string name);
        Task<List<NurseDTO>> Get_Nurse_By_Section(int secId);
        Task<NurseDTO> Create_Update_Nurse(NurseDTO nurseDto);
        Task<bool> Delete_Nurse_By_Id(int id);
    }
}
