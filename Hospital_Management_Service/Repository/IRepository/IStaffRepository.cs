using Hospital_Management_Service.Models.DTOs;
    
namespace Hospital_Management_Service.Repository.IRepository
{
    public interface IStaffRepository
    {
        Task<List<StaffDTO>> Get_Staffs();
        Task<StaffDTO> Get_Staff_By_Id(int id);
        Task<List<StaffDTO>> Get_Staff_By_Name(string name);
        Task<List<StaffDTO>> Get_Staff_By_Ward(int wid);
        Task<List<StaffDTO>> Get_Staff_By_Section(int sid);
        Task<StaffDTO> Create_Update_Staff(StaffDTO staffDto);
        Task<bool> Delete_Staff_By_Id(int id);
    }
}
