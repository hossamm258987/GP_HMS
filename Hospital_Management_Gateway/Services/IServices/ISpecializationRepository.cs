using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface ISpecializationRepository
    {
        Task<T> Get_Specializations<T>();
        Task<T> Get_Specialization_By_Id<T>(int id);
        Task<T> Get_Specialization_By_Name<T>(string name);
        Task<T> Create_Specialization<T>(SpecializationDTO specializationDto);
        Task<T> Update_Specialization<T>(SpecializationDTO specializationDto);
        Task<T> Delete_Specialization_By_Id<T>(int id);
    }
}
