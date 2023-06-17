using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Clinic_Management_Service.Data;
using Clinic_Management_Service.Models;
using Clinic_Management_Service.Models.DTOs;
using Clinic_Management_Service.Repository.IRepository;

namespace Clinic_Management_Service.Repository
{
    public class DocMExaminationRepository : IDocMExaminationRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public DocMExaminationRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<DocMExaminationDTO>> Get_DocMExaminations()
        {
            List<DocMExamination> docMExaminations = await _db.DocMExaminations.ToListAsync();
            return _mapper.Map<List<DocMExaminationDTO>>(docMExaminations);
        }

        public async Task<DocMExaminationDTO> Get_DocMExamination_By_Id(int id)
        {
            DocMExamination docMExamination = await _db.DocMExaminations.FirstOrDefaultAsync(h => h.Id == id);
            return _mapper.Map<DocMExaminationDTO>(docMExamination);
        }

        public async Task<List<DocMExaminationDTO>> Get_DocMExamination_By_Doctor(int did)
        {
            List<DocMExamination> docMExaminations = await _db.DocMExaminations.Where(h => h.Doctor.EmployeeId == did).ToListAsync();
            return _mapper.Map<List<DocMExaminationDTO>>(docMExaminations);
        }

        public async Task<List<DocMExaminationDTO>> Get_DocMExamination_By_MExamination(int meid)
        {
            List<DocMExamination> docMExaminations = await _db.DocMExaminations.Where(h => h.MExamination.Id == meid).ToListAsync();
            return _mapper.Map<List<DocMExaminationDTO>>(docMExaminations);
        }

        public async Task<List<DocMExaminationDTO>> Get_MExamination_By_Section(int sid, int meid)
        {
            List<DocMExamination> docMExaminations = await _db.DocMExaminations.Where(h => h.MExamination.Id == meid 
                && h.Doctor.Section.Id == sid).ToListAsync();
            return _mapper.Map<List<DocMExaminationDTO>>(docMExaminations);
        }

        public async Task<DocMExaminationDTO> Create_Update_DocMExamination(DocMExaminationDTO docMExaminationDto)
        {
            DocMExamination docMExamination = _mapper.Map<DocMExaminationDTO, DocMExamination>(docMExaminationDto);

            Doctor doctor = await _db.Doctors.FirstOrDefaultAsync(s => s.EmployeeId == docMExamination.Doctor.EmployeeId);
            if (doctor == null)
            {
                _db.Doctors.Add(docMExamination.Doctor);
                await _db.SaveChangesAsync();
            }
            else
            {
                _db.Doctors.Update(docMExamination.Doctor);
                await _db.SaveChangesAsync();
            }

            Section section = await _db.Sections.FirstOrDefaultAsync(s => s.Id == docMExamination.Doctor.Section.Id);
            if (section == null)
            {
                _db.Sections.Add(doctor.Section);
                await _db.SaveChangesAsync();
            }
            else
            {
                _db.Sections.Update(doctor.Section);
                await _db.SaveChangesAsync();
            }
            SectionType sectionType = await _db.SectionTypes.FirstOrDefaultAsync(s => s.Id == section.Type.Id);
            if (sectionType == null)
            {
                _db.SectionTypes.Add(section.Type);
                await _db.SaveChangesAsync();
            }
            else
            {
                _db.SectionTypes.Update(section.Type);
                await _db.SaveChangesAsync();
            }
            Hospital hospital = await _db.Hospitals.FirstOrDefaultAsync(s => s.Id == section.Hospital.Id);
            if (hospital == null)
            {
                _db.Hospitals.Add(section.Hospital);
                await _db.SaveChangesAsync();
            }
            else
            {
                _db.Hospitals.Update(section.Hospital);
                await _db.SaveChangesAsync();
            }

            if (docMExamination.Id > 0)
            {
                _db.DocMExaminations.Update(docMExamination);
            }
            else
            {
                _db.DocMExaminations.Add(docMExamination);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<DocMExamination, DocMExaminationDTO>(docMExamination);
        }

        public async Task<bool> Delete_DocMExamination_By_Id(int id)
        {
            try
            {
                DocMExamination docMExamination = await _db.DocMExaminations.FirstOrDefaultAsync(h => h.Id == id);
                if (docMExamination == null)
                {
                    return false; ;
                }
                _db.DocMExaminations.Remove(docMExamination);
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
