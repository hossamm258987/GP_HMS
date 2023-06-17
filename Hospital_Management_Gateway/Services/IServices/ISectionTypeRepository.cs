using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface ISectionTypeRepository
    {
        Task<T> Get_SectionTypes<T>();
        Task<T> Get_SectionType_By_Id<T>(int id);
        Task<T> Get_SectionType_By_Name<T>(string name);
        Task<T> Create_SectionType<T>(SectionTypeDTO sectionTypeDto);
        Task<T> Update_SectionType<T>(SectionTypeDTO sectionTypeDto);
        Task<T> Delete_SectionType_By_Id<T>(int id);
    }
}
