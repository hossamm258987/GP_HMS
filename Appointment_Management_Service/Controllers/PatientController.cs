using Microsoft.AspNetCore.Mvc;
using Appointment_Management_Service.Repository.IRepository;
using Appointment_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appointment_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        protected ResponseDTO _response;
        private IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            this._response = new ResponseDTO();
            _patientRepository = patientRepository;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<PatientDTO> PatientDTOs = await _patientRepository.Get_Patients();
                _response.Result = PatientDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                PatientDTO PatientDTO = await _patientRepository.Get_Patient_By_Id(id);
                _response.Result = PatientDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<PatientsController>/name/Patient
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<PatientDTO> PatientDTOs = await _patientRepository.Get_Patient_By_Name(name);
                _response.Result = PatientDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<PatientsController>
        [HttpPost]
        public async Task<object> Post([FromBody] PatientDTO PatientDTO)
        {
            try
            {
                PatientDTO model = await _patientRepository.Create_Update_Patient(PatientDTO);
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

        // PUT api/<PatientsController>
        [HttpPut]
        public async Task<object> Put([FromBody] PatientDTO PatientDTO)
        {
            try
            {
                PatientDTO model = await _patientRepository.Create_Update_Patient(PatientDTO);
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

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _patientRepository.Delete_Patient_By_Id(id);
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
