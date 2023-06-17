using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface ISectionRepository
    {
        Task<List<SectionDTO>> Get_Sections();
        Task<SectionDTO> Get_Section_By_Id(int id);
        Task<List<SectionDTO>> Get_Section_By_Name(string name);
        Task<List<SectionDTO>> Get_Section_By_Hospital(int hid);
        Task<SectionDTO> Create_Update_Section(SectionDTO sectionDto);
        Task<bool> Delete_Section_By_Id(int id);
    }
}
