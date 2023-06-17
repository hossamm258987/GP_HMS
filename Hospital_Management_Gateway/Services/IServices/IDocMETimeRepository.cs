using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IDocMETimeRepository
    {
        Task<T> Get_DocMETimes<T>();
        Task<T> Get_DocMETime_By_Id<T>(int id);
        Task<T> Get_DocMETime_By_Name<T>(string name);
        Task<T> Get_DocMETime_By_DocME<T>(int dmeid);
        Task<T> Get_DocMETime_By_Doctor<T>(int did);
        Task<T> Create_DocMETime<T>(DocMETimeDTO docMETimeDto);
        Task<T> Update_DocMETime<T>(DocMETimeDTO docMETimeDto);
        Task<T> Delete_DocMETime_By_Id<T>(int id);
    }
}
