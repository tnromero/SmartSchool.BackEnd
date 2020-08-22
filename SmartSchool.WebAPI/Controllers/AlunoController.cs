using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: <AlunoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAlunosAsync(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //return BadRequest($"Erro: {ex.Message}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        // GET <AlunoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int alunoId)
        {
            try
            {
                var result = await _repo.GetAlunoAsyncById(alunoId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //return BadRequest($"Erro: {ex.Message}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        // GET <AlunoController>/<ByDisciplina>/5
        [HttpGet("ByDisciplina/{disciplinaId}")]
        public async Task<IActionResult> GetByDisciplina(int disciplinaId)
        {
            try
            {
                var result = await _repo.GetAlunosAsyncByDisciplinaId(disciplinaId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //return BadRequest($"Erro: {ex.Message}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        // POST <AlunoController>
        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }

            }
            catch (Exception ex)
            {
                //return BadRequest($"Erro: {ex.Message}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        // PUT <AlunoController>/5
        [HttpPut("{alunoId}")]
        public async Task<IActionResult> Put(int alunoId, Aluno model)
        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncById(alunoId, false);
                if (aluno == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }

            }
            catch (Exception ex)
            {
                //return BadRequest($"Erro: {ex.Message}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        // DELETE <AlunoController>/5
        [HttpDelete("{alunoId}")]
        public async Task<IActionResult> Delete(int alunoId)
        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncById(alunoId, false);
                if (aluno == null) return NotFound();

                _repo.Delete(aluno);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }

            }
            catch (Exception ex)
            {
                //return BadRequest($"Erro: {ex.Message}");
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }
    }
}
