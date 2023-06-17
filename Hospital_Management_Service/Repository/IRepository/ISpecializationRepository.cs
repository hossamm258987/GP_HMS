using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface ISpecializationRepository
    {
        Task<List<SpecializationDTO>> Get_Specializations();
        Task<SpecializationDTO> Get_Specialization_By_Id(int id);
        Task<List<SpecializationDTO>> Get_Specialization_By_Name(string name);
        Task<SpecializationDTO> Create_Update_Specialization(SpecializationDTO specializationDto);
        Task<bool> Delete_Specialization_By_Id(int id);
    }
}
