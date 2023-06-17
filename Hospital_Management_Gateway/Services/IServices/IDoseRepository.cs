using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IDoseRepository
    {
        Task<T> Get_Doses<T>();
        Task<T> Get_Dose_By_Id<T>(int id);
        Task<T> Get_Dose_By_Name<T>(string name);
        Task<T> Create_Dose<T>(DoseDTO doseDto);
        Task<T> Update_Dose<T>(DoseDTO doseDto);
        Task<T> Delete_Dose_By_Id<T>(int id);
    }
}
