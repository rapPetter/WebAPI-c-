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
using Microsoft.Extensions.WebEncoders.Testing;
using System.Drawing;

namespace LabSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Atendimentos : ControllerBase
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public Atendimentos(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPut]
        public async Task<IActionResult> PutSituacao(AtendimentoDto atendimentoDto)
        {
            var alunoBusca = await _context.Alunos.FindAsync(atendimentoDto.CodigoAluno);
            var pedagogoBusca = await _context.Pedagogos.FindAsync(atendimentoDto.CodigoPedagogo);
            try
            {

                if (atendimentoDto.CodigoAluno == 0 || atendimentoDto.CodigoPedagogo == 0)
                {
                    return BadRequest("Favor informar os codigos.");
                }


                if (alunoBusca is null || pedagogoBusca is null)
                {
                    if (alunoBusca is null)
                    {
                        return NotFound("Aluno não encontrado com esse codigo.");
                    }
                    else if (pedagogoBusca is null)
                    {
                        return NotFound("Pedagogo não encontrado com esse codigo.");
                    }
                    else
                    {
                        return NotFound("Aluno e Pedagogo não encontrado com esses codigos.");
                    }
                }

                if (alunoBusca.TotalDeAtendimentoPedagogicos == 0)
                {
                    alunoBusca.TotalDeAtendimentoPedagogicos = +1;
                }
                else if (pedagogoBusca.TotalAtendimentosPedagogicos == 0)
                {
                    pedagogoBusca.TotalAtendimentosPedagogicos = +1;
                }
                else
                {
                    alunoBusca.TotalDeAtendimentoPedagogicos = alunoBusca.TotalDeAtendimentoPedagogicos + 1;
                    pedagogoBusca.TotalAtendimentosPedagogicos = pedagogoBusca.TotalAtendimentosPedagogicos + 1;
                }
                _context.Entry(alunoBusca).State = EntityState.Modified;
                _context.Entry(pedagogoBusca).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            var aluno = _mapper.Map<AlunoDto>(alunoBusca);
            var pedagogo = _mapper.Map<PedagogoDto>(pedagogoBusca);

            return Ok(new { aluno, pedagogo });
        }

    }
}
