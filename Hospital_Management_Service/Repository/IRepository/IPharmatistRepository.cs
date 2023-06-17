using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface IPharmatistRepository
    {
        Task<List<PharmatistDTO>> Get_Pharmatists();
        Task<PharmatistDTO> Get_Pharmatist_By_Id(int id);
        Task<List<PharmatistDTO>> Get_Pharmatist_By_Name(string name);
        Task<List<PharmatistDTO>> Get_Pharmatist_By_Section(int secId);
        Task<PharmatistDTO> Create_Update_Pharmatist(PharmatistDTO pharmatistDto);
        Task<bool> Delete_Pharmatist_By_Id(int id);
    }
}
