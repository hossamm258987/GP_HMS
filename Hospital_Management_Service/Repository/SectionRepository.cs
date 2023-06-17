using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_Service.Data;
using Hospital_Management_Service.Models;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

namespace Hospital_Management_Service.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public SectionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<SectionDTO>> Get_Sections()
        {
            List<Section> sections = await _db.Sections.ToListAsync();
            return _mapper.Map<List<SectionDTO>>(sections);
        }

        public async Task<SectionDTO> Get_Section_By_Id(int id)
        {
            Section section = await _db.Sections.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<SectionDTO>(section);
        }

        public async Task<List<SectionDTO>> Get_Section_By_Name(string name)
        {
            List<Section> sections = await _db.Sections.Where(h => h.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<SectionDTO>>(sections);
        }

        public async Task<List<SectionDTO>> Get_Section_By_Hospital(int hid)
        {
            List<Section> sections = await _db.Sections.Where(h => h.Hospital.Id == hid).ToListAsync();
            return _mapper.Map<List<SectionDTO>>(sections);
        }

        public async Task<SectionDTO> Create_Update_Section(SectionDTO sectionDto)
        {
            Section section = _mapper.Map<SectionDTO, Section>(sectionDto);
            if (section.Id > 0)
            {
                _db.Sections.Update(section);
            }
            else
            {
                _db.Sections.Add(section);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Section, SectionDTO>(section);
        }

        public async Task<bool> Delete_Section_By_Id(int id)
        {
            try
            {
                Section section = await _db.Sections.FirstOrDefaultAsync(h => h.Id == id);
                if (section == null)
                {
                    return false; ;
                }
                _db.Sections.Remove(section);
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
