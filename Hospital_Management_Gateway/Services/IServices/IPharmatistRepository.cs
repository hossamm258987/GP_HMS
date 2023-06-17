using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IPharmatistRepository
    {
        Task<T> Get_Pharmatists<T>();
        Task<T> Get_Pharmatist_By_Id<T>(int id);
        Task<T> Get_Pharmatist_By_Name<T>(string name);
        Task<T> Get_Pharmatist_By_Section<T>(int secId);
        Task<T> Create_Pharmatist<T>(PharmatistDTO pharmatistDto);
        Task<T> Update_Pharmatist<T>(PharmatistDTO pharmatistDto);
        Task<T> Delete_Pharmatist_By_Id<T>(int id);
    }
}
