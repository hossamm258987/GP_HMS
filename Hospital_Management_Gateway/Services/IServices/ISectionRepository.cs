using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface ISectionRepository
    {
        Task<T> Get_Sections<T>();
        Task<T> Get_Section_By_Id<T>(int id);
        Task<T> Get_Section_By_Name<T>(string name);
        Task<T> Get_Section_By_Hospital<T>(int hid);
        Task<T> Create_Section<T>(SectionDTO sectionDto);
        Task<T> Update_Section<T>(SectionDTO sectionDto);
        Task<T> Delete_Section_By_Id<T>(int id);
    }
}
