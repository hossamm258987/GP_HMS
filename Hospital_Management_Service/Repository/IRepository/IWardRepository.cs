using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface IWardRepository
    {
        Task<List<WardDTO>> Get_Wards();
        Task<WardDTO> Get_Ward_By_Id(int id);
        Task<List<WardDTO>> Get_Ward_By_Name(string name);
        Task<WardDTO> Create_Update_Ward(WardDTO wardDto);
        Task<bool> Delete_Ward_By_Id(int id);
    }
}
