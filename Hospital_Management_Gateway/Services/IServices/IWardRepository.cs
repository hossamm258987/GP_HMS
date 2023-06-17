using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IWardRepository
    {
        Task<T> Get_Wards<T>();
        Task<T> Get_Ward_By_Id<T>(int id);
        Task<T> Get_Ward_By_Name<T>(string name);
        Task<T> Create_Ward<T>(WardDTO wardDto);
        Task<T> Update_Ward<T>(WardDTO wardDto);
        Task<T> Delete_Ward_By_Id<T>(int id);
    }
}
