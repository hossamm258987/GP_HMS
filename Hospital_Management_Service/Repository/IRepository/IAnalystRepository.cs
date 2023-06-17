using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface IAnalystRepository
    {
        Task<List<AnalystDTO>> Get_Analysts();
        Task<AnalystDTO> Get_Analyst_By_Id(int id);
        Task<List<AnalystDTO>> Get_Analyst_By_Name(string name);
        Task<List<AnalystDTO>> Get_Analyst_By_Section(int secId);
        Task<AnalystDTO> Create_Update_Analyst(AnalystDTO analystDto);
        Task<bool> Delete_Analyst_By_Id(int id);
    }
}
