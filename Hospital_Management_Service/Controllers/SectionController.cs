using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Repository.IRepository;
using Hospital_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        protected ResponseDTO _response;
        private ISectionRepository _sectionRepository;

        public SectionController(ISectionRepository sectionRepository)
        {
            this._response = new ResponseDTO();
            _sectionRepository = sectionRepository;
        }
        // GET: api/<SectionsController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<SectionDTO> sectionDTOs = await _sectionRepository.Get_Sections();
                _response.Result = sectionDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<SectionsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                SectionDTO sectionDTO = await _sectionRepository.Get_Section_By_Id(id);
                _response.Result = sectionDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<SectionsController>/name/Section
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<SectionDTO> sectionDTOs = await _sectionRepository.Get_Section_By_Name(name);
                _response.Result = sectionDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        
        // GET api/<SectionsController>/hospital/Sections
        [HttpGet("hospital/{hid}")]
        public async Task<object> Get_By_Hospital(int hid)
        {
            try
            {
                IEnumerable<SectionDTO> sectionDTOs = await _sectionRepository.Get_Section_By_Hospital(hid);
                _response.Result = sectionDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<SectionsController>
        [HttpPost]
        public async Task<object> Post([FromBody] SectionDTO sectionDTO)
        {
            try
            {
                SectionDTO model = await _sectionRepository.Create_Update_Section(sectionDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // PUT api/<SectionsController>
        [HttpPut]
        public async Task<object> Put([FromBody] SectionDTO sectionDTO)
        {
            try
            {
                SectionDTO model = await _sectionRepository.Create_Update_Section(sectionDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE api/<SectionsController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _sectionRepository.Delete_Section_By_Id(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
