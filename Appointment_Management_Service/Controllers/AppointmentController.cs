using Microsoft.AspNetCore.Mvc;
using Appointment_Management_Service.Repository.IRepository;
using Appointment_Management_Service.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appointment_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        protected ResponseDTO _response;
        private IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            this._response = new ResponseDTO();
            _appointmentRepository = appointmentRepository;
        }
        // GET: api/<AppointmentsController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<AppointmentDTO> AppointmentDTOs = await _appointmentRepository.Get_Appointments();
                _response.Result = AppointmentDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                AppointmentDTO AppointmentDTO = await _appointmentRepository.Get_Appointment_By_Id(id);
                _response.Result = AppointmentDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<AppointmentsController>/name/Appointment
        [HttpGet("name/{name}")]
        public async Task<object> Get(string name)
        {
            try
            {
                IEnumerable<AppointmentDTO> AppointmentDTOs = await _appointmentRepository.Get_Appointment_By_Name(name);
                _response.Result = AppointmentDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<AppointmentsController>/name/Appointment
        [HttpGet("sec/{sid}")]
        public async Task<object> Get_By_Sec(int sid)
        {
            try
            {
                IEnumerable<AppointmentDTO> AppointmentDTOs = await _appointmentRepository.Get_Appointment_By_Section(sid);
                _response.Result = AppointmentDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<AppointmentsController>/name/Appointment
        [HttpGet("sec/{sid}/{date}")]
        public async Task<object> Get_By_SecDate(int sid, DateTime date)
        {
            try
            {
                IEnumerable<AppointmentDTO> AppointmentDTOs = await _appointmentRepository.Get_Appointment_By_Section(sid, date);
                _response.Result = AppointmentDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<AppointmentsController>/name/Appointment
        [HttpGet("appnum/{number}/{date}")]
        public async Task<object> Get_By_AppNum(int number, DateTime date)
        {
            try
            {
                IEnumerable<AppointmentDTO> AppointmentDTOs = await _appointmentRepository.Get_Appointment_By_Section(number, date);
                _response.Result = AppointmentDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET api/<AppointmentsController>/name/Appointment
        [HttpGet("pateint/{pid}")]
        public async Task<object> Get_By_Patient(int pid)
        {
            try
            {
                IEnumerable<AppointmentDTO> AppointmentDTOs = await _appointmentRepository.Get_Appointment_By_Patient(pid);
                _response.Result = AppointmentDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public async Task<object> Post([FromBody] AppointmentDTO AppointmentDTO)
        {
            try
            {
                AppointmentDTO model = await _appointmentRepository.Create_Update_Appointment(AppointmentDTO);
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

        // PUT api/<AppointmentsController>
        [HttpPut]
        public async Task<object> Put([FromBody] AppointmentDTO AppointmentDTO)
        {
            try
            {
                AppointmentDTO model = await _appointmentRepository.Create_Update_Appointment(AppointmentDTO);
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

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _appointmentRepository.Delete_Appointment_By_Id(id);
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
