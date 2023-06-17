using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ReceptionistRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ReceptionistDTO>> Get_Receptionists()
        {
            List<Receptionist> receptionists = await _db.Receptionists.ToListAsync();
            return _mapper.Map<List<ReceptionistDTO>>(receptionists);
        }

        public async Task<ReceptionistDTO> Get_Receptionist_By_Id(int id)
        {
            Receptionist receptionist = await _db.Receptionists.FirstOrDefaultAsync(d => d.EmployeeId == id);
            return _mapper.Map<ReceptionistDTO>(receptionist);
        }

        public async Task<List<ReceptionistDTO>> Get_Receptionist_By_Name(string name)
        {
            List<Receptionist> receptionists = await _db.Receptionists.Where(d => d.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<ReceptionistDTO>>(receptionists);
        }

        public async Task<List<ReceptionistDTO>> Get_Receptionist_By_Section(int secId)
        {
            List<Receptionist> receptionists = await _db.Receptionists.Where(d => d.Section.Id == secId).ToListAsync();
            return _mapper.Map<List<ReceptionistDTO>>(receptionists);
        }

        public async Task<ReceptionistDTO> Create_Update_Receptionist(ReceptionistDTO receptionistDto)
        {
            Receptionist receptionist = _mapper.Map<ReceptionistDTO, Receptionist>(receptionistDto);
            if (receptionist.EmployeeId > 0)
            {
                _db.Receptionists.Update(receptionist);
            }
            else
            {
                _db.Receptionists.Add(receptionist);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Receptionist, ReceptionistDTO>(receptionist);
        }

        public async Task<bool> Delete_Receptionist_By_Id(int id)
        {
            try
            {
                Receptionist receptionist = await _db.Receptionists.FirstOrDefaultAsync(d => d.EmployeeId == id);
                if (receptionist == null)
                {
                    return false; ;
                }
                _db.Receptionists.Remove(receptionist);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
