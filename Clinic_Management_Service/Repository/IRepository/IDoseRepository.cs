using Clinic_Management_Service.Models.DTOs;

namespace Clinic_Management_Service.Repository.IRepository
{
    public interface IDoseRepository
    {
        Task<List<DoseDTO>> Get_Doses();
        Task<DoseDTO> Get_Dose_By_Id(int id);
        Task<List<DoseDTO>> Get_Dose_By_Name(string name);
        Task<DoseDTO> Create_Update_Dose(DoseDTO doseDto);
        Task<bool> Delete_Dose_By_Id(int id);
    }
}
