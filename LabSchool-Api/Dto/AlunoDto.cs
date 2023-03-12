using LabSchool_Api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace LabSchool_Api.Dto
{
    public class AlunoDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimentoConverter;
        public string Datanascimento
        {
            get { return this.DataNascimentoConverter.ToShortDateString(); }
            set { this.DataNascimentoConverter = DateTime.Parse(value); }
        }
        public long Cpf { get; set; }
        public string Situacao { get; set; } = null!;
        public float Nota { get; set; }
        public int Atendimentos { get; set; }
    }
    public class CadastroAlunoDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public long Cpf { get; set; }
        public string Situacao { get; set; } = null!;
        public float Nota { get; set; }
    }
    public class SituacaoAlunoDto
    {
        public string Situacao { get; set; } = null!;
    }
}
