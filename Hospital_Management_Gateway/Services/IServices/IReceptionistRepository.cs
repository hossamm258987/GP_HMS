using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IReceptionistRepository
    {
        Task<T> Get_Receptionists<T>();
        Task<T> Get_Receptionist_By_Id<T>(int id);
        Task<T> Get_Receptionist_By_Name<T>(string name);
        Task<T> Get_Receptionist_By_Section<T>(int secId);
        Task<T> Create_Receptionist<T>(ReceptionistDTO receptionistDto);
        Task<T> Update_Receptionist<T>(ReceptionistDTO receptionistDto);
        Task<T> Delete_Receptionist_By_Id<T>(int id);
    }
}
