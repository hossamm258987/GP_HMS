using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface INurseRepository
    {
        Task<T> Get_Nurses<T>();
        Task<T> Get_Nurse_By_Id<T>(int id);
        Task<T> Get_Nurse_By_Name<T>(string name);
        Task<T> Get_Nurse_By_Section<T>(int secId);
        Task<T> Create_Nurse<T>(NurseDTO nurseDto);
        Task<T> Update_Nurse<T>(NurseDTO nurseDto);
        Task<T> Delete_Nurse_By_Id<T>(int id);
    }
}
