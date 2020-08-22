using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        // GET: <ProfessoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professor");
        }

        // GET <ProfessoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST <ProfessoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <ProfessoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <ProfessoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
