using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public HospitalRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<HospitalDTO>> Get_Hospitals()
        {
            List<Hospital> hospitals = await _db.Hospitals.ToListAsync();
            return _mapper.Map<List<HospitalDTO>>(hospitals);
        }

        public async Task<HospitalDTO> Get_Hospital_By_Id(int id)
        {
            Hospital hospital = await _db.Hospitals.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<HospitalDTO>(hospital);
        }

        public async Task<List<HospitalDTO>> Get_Hospital_By_Name(string name)
        {
            List<Hospital> hospitals = await _db.Hospitals.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<HospitalDTO>>(hospitals);
        }

        public async Task<HospitalDTO> Create_Update_Hospital(HospitalDTO hospitalDto)
        {
            Hospital hospital = _mapper.Map<HospitalDTO, Hospital>(hospitalDto);
            if (hospital.Id > 0)
            {
                _db.Hospitals.Update(hospital);
            }
            else
            {
                _db.Hospitals.Add(hospital);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Hospital, HospitalDTO>(hospital);
        }

        public async Task<bool> Delete_Hospital_By_Id(int id)
        {
            try
            {
                Hospital hospital = await _db.Hospitals.FirstOrDefaultAsync(h => h.Id == id);
                if (hospital == null)
                {
                    return false; ;
                }
                _db.Hospitals.Remove(hospital);
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
