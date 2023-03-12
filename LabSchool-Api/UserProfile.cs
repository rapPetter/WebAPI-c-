using AutoMapper;
using LabSchool_Api.Dto;
using LabSchool_Api.Models;

namespace LabSchool_Api
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(dto => dto.Nota, act => act.MapFrom(model => model.NotaProcessoSeletivo))
                .ForMember(dto => dto.DataNascimentoConverter, act => act.MapFrom(model => model.DataNascimento))
                .ForMember(dto => dto.Situacao, act => act.MapFrom(model => model.SituacaoMatricula))
                .ForMember(dto => dto.Nota, act => act.MapFrom(model => model.NotaProcessoSeletivo))
                .ForMember(dto => dto.Atendimentos, act => act.MapFrom(model => model.TotalDeAtendimentoPedagogicos))
                .ReverseMap();

            CreateMap<CadastroAlunoDto, Aluno>()
                .ForMember(dto => dto.SituacaoMatricula, act => act.MapFrom(model => model.Situacao))
                .ForMember(dto => dto.NotaProcessoSeletivo, act => act.MapFrom(model => model.Nota))
                .ReverseMap(); 

            CreateMap<SituacaoAlunoDto, Aluno>()
                .ForMember(dto => dto.SituacaoMatricula, act => act.MapFrom(model => model.Situacao))
                .ReverseMap();

            CreateMap<ProfessorDto, Professor>()
                 .ForMember(dto => dto.FormacaoAcademica, act => act.MapFrom(model => model.Formacao))
                 .ForMember(dto => dto.ExperienciaEmDesenvolvimento, act => act.MapFrom(model => model.Experiencia))
                 .ForMember(dto => dto.DataNascimento, act => act.MapFrom(model => model.DataNascimentoConverter))
                 .ReverseMap();

            CreateMap<PedagogoDto, Pedagogo>()
                .ForMember(dto => dto.DataNascimento, act => act.MapFrom(model => model.DataNascimentoConverter))
                .ForMember(dto => dto.TotalAtendimentosPedagogicos, act => act.MapFrom(model => model.Atendimentos))
                .ReverseMap();
            CreateMap<AtendimentoDto, Aluno>()
                .ForMember(dto => dto.Codigo, act => act.MapFrom(model => model.CodigoAluno))
                .ReverseMap();

            CreateMap<AtendimentoDto, Pedagogo>()
                .ForMember(dto => dto.Codigo, act => act.MapFrom(model => model.CodigoPedagogo))
                .ReverseMap();
        }
        
    }
}
