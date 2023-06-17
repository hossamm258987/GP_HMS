using Hospital_Management_Gateway.Models;

namespace Hospital_Management_Gateway.Repository.IRepository
{
    public interface IAnalystRepository
    {
        Task<T> Get_AnalystsAsync<T>();
        Task<T> Get_Analyst_By_Id<T>(int id);
        Task<T> Get_Analyst_By_Name<T>(string name);
        Task<T> Get_Analyst_By_Section<T>(int secId);
        Task<T> Create_Analyst<T>(AnalystDTO analystDto);
        Task<T> Update_Analyst<T>(AnalystDTO analystDto);
        Task<T> Delete_Analyst_By_Id<T>(int id);
    }
}
