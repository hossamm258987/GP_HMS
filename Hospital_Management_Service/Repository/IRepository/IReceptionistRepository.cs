using Hospital_Management_Service.Models.DTOs;

namespace Hospital_Management_Service.Repository.IRepository
{
    public interface IReceptionistRepository
    {
        Task<List<ReceptionistDTO>> Get_Receptionists();
        Task<ReceptionistDTO> Get_Receptionist_By_Id(int id);
        Task<List<ReceptionistDTO>> Get_Receptionist_By_Name(string name);
        Task<List<ReceptionistDTO>> Get_Receptionist_By_Section(int secId);
        Task<ReceptionistDTO> Create_Update_Receptionist(ReceptionistDTO receptionistDto);
        Task<bool> Delete_Receptionist_By_Id(int id);
    }
}
