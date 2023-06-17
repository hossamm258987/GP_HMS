using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public SpecializationRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<SpecializationDTO>> Get_Specializations()
        {
            List<Specialization> specializations = await _db.Specializations.ToListAsync();
            return _mapper.Map<List<SpecializationDTO>>(specializations);
        }

        public async Task<SpecializationDTO> Get_Specialization_By_Id(int id)
        {
            Specialization specialization = await _db.Specializations.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<SpecializationDTO>(specialization);
        }

        public async Task<List<SpecializationDTO>> Get_Specialization_By_Name(string name)
        {
            List<Specialization> specializations = await _db.Specializations.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<SpecializationDTO>>(specializations);
        }

        public async Task<SpecializationDTO> Create_Update_Specialization(SpecializationDTO specializationDto)
        {
            Specialization specialization = _mapper.Map<SpecializationDTO, Specialization>(specializationDto);
            if (specialization.Id > 0)
            {
                _db.Specializations.Update(specialization);
            }
            else
            {
                _db.Specializations.Add(specialization);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Specialization, SpecializationDTO>(specialization);
        }

        public async Task<bool> Delete_Specialization_By_Id(int id)
        {
            try
            {
                Specialization specialization = await _db.Specializations.FirstOrDefaultAsync(h => h.Id == id);
                if (specialization == null)
                {
                    return false; ;
                }
                _db.Specializations.Remove(specialization);
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
