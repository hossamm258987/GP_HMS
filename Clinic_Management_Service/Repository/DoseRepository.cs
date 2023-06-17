using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Clinic_Management_Service.Data;
using Clinic_Management_Service.Models;
using Clinic_Management_Service.Models.DTOs;
using Clinic_Management_Service.Repository.IRepository;

namespace Clinic_Management_Service.Repository
{
    public class DoseRepository : IDoseRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public DoseRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<DoseDTO>> Get_Doses()
        {
            List<Dose> doses = await _db.Doses.ToListAsync();
            return _mapper.Map<List<DoseDTO>>(doses);
        }

        public async Task<DoseDTO> Get_Dose_By_Id(int id)
        {
            Dose dose = await _db.Doses.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<DoseDTO>(dose);
        }

        public async Task<List<DoseDTO>> Get_Dose_By_Name(string name)
        {
            List<Dose> doses = await _db.Doses.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<DoseDTO>>(doses);
        }

        public async Task<DoseDTO> Create_Update_Dose(DoseDTO doseDto)
        {
            Dose dose = _mapper.Map<DoseDTO, Dose>(doseDto);
            if (dose.Id > 0)
            {
                _db.Doses.Update(dose);
            }
            else
            {
                _db.Doses.Add(dose);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Dose, DoseDTO>(dose);
        }

        public async Task<bool> Delete_Dose_By_Id(int id)
        {
            try
            {
                Dose dose = await _db.Doses.FirstOrDefaultAsync(h => h.Id == id);
                if (dose == null)
                {
                    return false; ;
                }
                _db.Doses.Remove(dose);
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
