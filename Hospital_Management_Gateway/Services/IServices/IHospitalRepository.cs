using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IHospitalRepository
    {
        Task<T> Get_Hospitals<T>();
        Task<T> Get_Hospital_By_Id<T>(int id);
        Task<T> Get_Hospital_By_Name<T>(string name);
        Task<T> Create_Hospital<T>(HospitalDTO hospitalDto);
        Task<T> Update_Hospital<T>(HospitalDTO hospitalDto);
        Task<T> Delete_Hospital_By_Id<T>(int id);
    }
}
