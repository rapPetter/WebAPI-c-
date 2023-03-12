using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSchool_Api.Context;
using LabSchool_Api.Models;
using AutoMapper;
using LabSchool_Api.Dto;
using System.Collections;

namespace LabSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public AlunosController(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Aluno>> GetAluno(int codigo)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(codigo);

            if (aluno == null)
            {
                return NotFound("Código nao encontrado.");
            }
            var AlunosDtos = _mapper.Map<AlunoDto>(aluno);
            return Ok(AlunosDtos);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunoSituacao(string ?situacao)
        {
            var aluno = await _context.Alunos.ToListAsync();
            var AlunosDtos = _mapper.Map<IEnumerable<AlunoDto>>(aluno);
            var Procura = AlunosDtos.Where(w => w.Situacao == situacao).ToList();
            if (situacao is null)
            {
                if (_context.Alunos == null)
                {
                    return NotFound("NENHUM REGISTRO NO BANCO DE DADOS");
                }

                return Ok(AlunosDtos);
            }
            else if (Procura.Count ==0)
            {
                return NotFound("NENHUMA SITUAÇÃO IGUAL DA BUSCA FOI REGISTRADA.");
            }
            
            return Ok(Procura);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutAluno(int codigo , SituacaoAlunoDto situacaoAlunoDto)
        {
            var aluno = await _context.Alunos.FindAsync(codigo);
            if (aluno is null)
            {
                return NotFound("Aluno não encontrado com esse codigo.");
            }

            try
            {
                aluno.SituacaoMatricula = situacaoAlunoDto.Situacao;
                if (aluno.SituacaoMatricula== "" || aluno.SituacaoMatricula == "string")
                {
                    return BadRequest("Favor informar a situação da matricula.");
                }
                
                _context.Entry(aluno).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            var AlunosDtos = _mapper.Map<AlunoDto>(aluno);
            return Ok(AlunosDtos);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(CadastroAlunoDto cadastroAlunoDto)
        {
            var aluno = _mapper.Map<Aluno>(cadastroAlunoDto);

            var alunos = await _context.Alunos.ToListAsync();
            var AlunosDtos = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

            var verificarCpf = AlunosDtos.Where(w => w.Cpf == aluno.Cpf).ToList();

            if (verificarCpf.Count >= 1)
            {

                return Conflict("CPF já cadastrado.");

            }else
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { codigo = aluno.Codigo }, _mapper.Map<AlunoDto>(aluno));
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteAluno(int codigo)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }
            var aluno = await _context.Alunos.FindAsync(codigo);
            if (aluno == null)
            {
                return NotFound("Código não existente na base de dados.");
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return (_context.Alunos?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
