using Hospital_Management_Gateway.Models;
using Hospital_Management_Gateway.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management_Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointGateController : ControllerBase
    {
        private readonly IAnalystRepository _analystRepository;
        public AppointGateController(IAnalystRepository analystRepository)
        {
            _analystRepository = analystRepository;
        }
        // GET: api/<AppointGateController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AppointGateController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AppointGateController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppointGateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointGateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
