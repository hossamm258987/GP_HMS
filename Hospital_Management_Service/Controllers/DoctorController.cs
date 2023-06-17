using Microsoft.AspNetCore.Mvc;
using Hospital_Management_Service.Models.DTOs;
using Hospital_Management_Service.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        protected ResponseDTO _response;
        private IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            this._response = new ResponseDTO();
            _doctorRepository = doctorRepository;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<DoctorDTO> doctorDTOs = await _doctorRepository.Get_Doctors();
                _response.Result = doctorDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                DoctorDTO doctorDTO = await _doctorRepository.Get_Doctor_By_Id(id);
                _response.Result = doctorDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DoctorController>/name/doctor
        [HttpGet("name/{name}")]
        public async Task<object> Get(string Name)
        {
            try
            {
                List<DoctorDTO> doctorDTO = await _doctorRepository.Get_Doctor_By_Name(Name);
                _response.Result = doctorDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<DoctorController>/spec/Id
        [HttpGet("spec/{spid}")]
        public async Task<object> Get_By_Spec(int spid)
        {
            try
            {
                List<DoctorDTO> doctorDTO = await _doctorRepository.Get_Doctor_By_Specialization(spid);
                _response.Result = doctorDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<DoctorController>
        [HttpPost]
        public async Task<object> Post([FromBody] DoctorDTO doctorDTO)
        {
            try
            {
                DoctorDTO model = await _doctorRepository.Create_Update_Doctor(doctorDTO);
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

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public async Task<object> Put([FromBody] DoctorDTO doctorDTO)
        {
            try
            {
                DoctorDTO model = await _doctorRepository.Create_Update_Doctor(doctorDTO);
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

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _doctorRepository.Delete_Doctor_By_Id(id);
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
