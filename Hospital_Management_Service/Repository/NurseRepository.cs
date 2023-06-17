using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class NurseRepository : INurseRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public NurseRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<NurseDTO>> Get_Nurses()
        {
            List<Nurse> nurses = await _db.Nurses.ToListAsync();
            return _mapper.Map<List<NurseDTO>>(nurses);
        }

        public async Task<NurseDTO> Get_Nurse_By_Id(int id)
        {
            Nurse nurse = await _db.Nurses.FirstOrDefaultAsync(d => d.EmployeeId == id);
            return _mapper.Map<NurseDTO>(nurse);
        }

        public async Task<List<NurseDTO>> Get_Nurse_By_Name(string name)
        {
            List<Nurse> nurses = await _db.Nurses.Where(d => d.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<NurseDTO>>(nurses);
        }

        public async Task<List<NurseDTO>> Get_Nurse_By_Section(int secId)
        {
            List<Nurse> nurses = await _db.Nurses.Where(d => d.Section.Id == secId).ToListAsync();
            return _mapper.Map<List<NurseDTO>>(nurses);
        }

        public async Task<NurseDTO> Create_Update_Nurse(NurseDTO nurseDto)
        {
            Nurse nurse = _mapper.Map<NurseDTO, Nurse>(nurseDto);
            if (nurse.EmployeeId > 0)
            {
                _db.Nurses.Update(nurse);
            }
            else
            {
                _db.Nurses.Add(nurse);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Nurse, NurseDTO>(nurse);
        }

        public async Task<bool> Delete_Nurse_By_Id(int id)
        {
            try
            {
                Nurse nurse = await _db.Nurses.FirstOrDefaultAsync(d => d.EmployeeId == id);
                if (nurse == null)
                {
                    return false; ;
                }
                _db.Nurses.Remove(nurse);
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
