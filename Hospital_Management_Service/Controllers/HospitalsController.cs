using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        protected ResponseDTO _response;
        private IHospitalRepository _hospitalRepository;

        public HospitalsController(IHospitalRepository hospitalRepository)
        {
            this._response = new ResponseDTO();
            _hospitalRepository = hospitalRepository;
        }
        // GET: api/<HospitalsController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<HospitalDTO> hospitalDTOs = await _hospitalRepository.Get_Hospitals();
                _response.Result = hospitalDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<HospitalsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                HospitalDTO hospitalDTO = await _hospitalRepository.Get_Hospital_By_Id(id);
                _response.Result = hospitalDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<HospitalsController>/name/hospital
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<HospitalDTO> hospitalDTOs = await _hospitalRepository.Get_Hospital_By_Name(name);
                _response.Result = hospitalDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<HospitalsController>
        [HttpPost]
        public async Task<object> Post([FromBody] HospitalDTO hospitalDTO)
        {
            try
            {
                HospitalDTO model = await _hospitalRepository.Create_Update_Hospital(hospitalDTO);
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

        // PUT api/<HospitalsController>
        [HttpPut]
        public async Task<object> Put([FromBody] HospitalDTO hospitalDTO)
        {
            try
            {
                HospitalDTO model = await _hospitalRepository.Create_Update_Hospital(hospitalDTO);
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

        // DELETE api/<HospitalsController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _hospitalRepository.Delete_Hospital_By_Id(id);
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
