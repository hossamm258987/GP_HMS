using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class SectionTypeRepository : ISectionTypeRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public SectionTypeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<SectionTypeDTO>> Get_SectionTypes()
        {
            List<SectionType> sectionTypes = await _db.SectionTypes.ToListAsync();
            return _mapper.Map<List<SectionTypeDTO>>(sectionTypes);
        }

        public async Task<SectionTypeDTO> Get_SectionType_By_Id(int id)
        {
            SectionType sectionType = await _db.SectionTypes.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<SectionTypeDTO>(sectionType);
        }

        public async Task<List<SectionTypeDTO>> Get_SectionType_By_Name(string name)
        {
            List<SectionType> sectionTypes = await _db.SectionTypes.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<SectionTypeDTO>>(sectionTypes);
        }

        public async Task<SectionTypeDTO> Create_Update_SectionType(SectionTypeDTO sectionTypeDto)
        {
            SectionType sectionType = _mapper.Map<SectionTypeDTO, SectionType>(sectionTypeDto);
            if (sectionType.Id > 0)
            {
                _db.SectionTypes.Update(sectionType);
            }
            else
            {
                _db.SectionTypes.Add(sectionType);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<SectionType, SectionTypeDTO>(sectionType);
        }

        public async Task<bool> Delete_SectionType_By_Id(int id)
        {
            try
            {
                SectionType sectionType = await _db.SectionTypes.FirstOrDefaultAsync(h => h.Id == id);
                if (sectionType == null)
                {
                    return false; ;
                }
                _db.SectionTypes.Remove(sectionType);
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
