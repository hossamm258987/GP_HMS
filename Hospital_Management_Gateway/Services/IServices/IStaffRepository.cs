using Hospital_Management_Gateway.Models;
    
namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IStaffRepository
    {
        Task<T> Get_Staffs<T>();
        Task<T> Get_Staff_By_Id<T>(int id);
        Task<T> Get_Staff_By_Name<T>(string name);
        Task<T> Get_Staff_By_Ward<T>(int wid);
        Task<T> Get_Staff_By_Section<T>(int sid);
        Task<T> Create_Staff<T>(StaffDTO staffDto);
        Task<T> Update_Staff<T>(StaffDTO staffDto);
        Task<T> Delete_Staff_By_Id<T>(int id);
    }
}
