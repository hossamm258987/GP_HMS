using Clinic_Management_Service.Models.DTOs;

namespace Clinic_Management_Service.Repository.IRepository
{
    public interface IDocMETimeRepository
    {
        Task<List<DocMETimeDTO>> Get_DocMETimes();
        Task<DocMETimeDTO> Get_DocMETime_By_Id(int id);
        Task<List<DocMETimeDTO>> Get_DocMETime_By_Name(string name);
        Task<List<DocMETimeDTO>> Get_DocMETime_By_DocME(int dmeid);
        Task<List<DocMETimeDTO>> Get_DocMETime_By_Doctor(int did);
        Task<DocMETimeDTO> Create_Update_DocMETime(DocMETimeDTO docMETimeDto);
        Task<bool> Delete_DocMETime_By_Id(int id);
    }
}
