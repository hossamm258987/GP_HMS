using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Repository.IRepository;
using Hospital_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionTypeController : ControllerBase
    {
        protected ResponseDTO _response;
        private ISectionTypeRepository _sectionTypeRepository;

        public SectionTypeController(ISectionTypeRepository sectionTypeRepository)
        {
            this._response = new ResponseDTO();
            _sectionTypeRepository = sectionTypeRepository;
        }
        // GET: api/<SectionTypesController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<SectionTypeDTO> sectionTypeDTOs = await _sectionTypeRepository.Get_SectionTypes();
                _response.Result = sectionTypeDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<SectionTypesController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                SectionTypeDTO sectionTypeDTO = await _sectionTypeRepository.Get_SectionType_By_Id(id);
                _response.Result = sectionTypeDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<SectionTypesController>/name/SectionType
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<SectionTypeDTO> sectionTypeDTOs = await _sectionTypeRepository.Get_SectionType_By_Name(name);
                _response.Result = sectionTypeDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<SectionTypesController>
        [HttpPost]
        public async Task<object> Post([FromBody] SectionTypeDTO sectionTypeDTO)
        {
            try
            {
                SectionTypeDTO model = await _sectionTypeRepository.Create_Update_SectionType(sectionTypeDTO);
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

        // PUT api/<SectionTypesController>
        [HttpPut]
        public async Task<object> Put([FromBody] SectionTypeDTO sectionTypeDTO)
        {
            try
            {
                SectionTypeDTO model = await _sectionTypeRepository.Create_Update_SectionType(sectionTypeDTO);
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

        // DELETE api/<SectionTypesController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _sectionTypeRepository.Delete_SectionType_By_Id(id);
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
