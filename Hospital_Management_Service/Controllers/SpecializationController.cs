using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Repository.IRepository;
using Hospital_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        protected ResponseDTO _response;
        private ISpecializationRepository _specializationRepository;

        public SpecializationController(ISpecializationRepository specializationRepository)
        {
            this._response = new ResponseDTO();
            _specializationRepository = specializationRepository;
        }
        // GET: api/<SpecializationsController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<SpecializationDTO> specializationDTOs = await _specializationRepository.Get_Specializations();
                _response.Result = specializationDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<SpecializationsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                SpecializationDTO specializationDTO = await _specializationRepository.Get_Specialization_By_Id(id);
                _response.Result = specializationDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<SpecializationsController>/name/Specialization
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<SpecializationDTO> specializationDTOs = await _specializationRepository.Get_Specialization_By_Name(name);
                _response.Result = specializationDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<SpecializationsController>
        [HttpPost]
        public async Task<object> Post([FromBody] SpecializationDTO specializationDTO)
        {
            try
            {
                SpecializationDTO model = await _specializationRepository.Create_Update_Specialization(specializationDTO);
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

        // PUT api/<SpecializationsController>
        [HttpPut]
        public async Task<object> Put([FromBody] SpecializationDTO specializationDTO)
        {
            try
            {
                SpecializationDTO model = await _specializationRepository.Create_Update_Specialization(specializationDTO);
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

        // DELETE api/<SpecializationsController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _specializationRepository.Delete_Specialization_By_Id(id);
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
