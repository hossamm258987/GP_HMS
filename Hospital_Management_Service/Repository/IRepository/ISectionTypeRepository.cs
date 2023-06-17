using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface ISectionTypeRepository
    {
        Task<List<SectionTypeDTO>> Get_SectionTypes();
        Task<SectionTypeDTO> Get_SectionType_By_Id(int id);
        Task<List<SectionTypeDTO>> Get_SectionType_By_Name(string name);
        Task<SectionTypeDTO> Create_Update_SectionType(SectionTypeDTO sectionTypeDto);
        Task<bool> Delete_SectionType_By_Id(int id);
    }
}
