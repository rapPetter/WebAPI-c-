namespace LabSchool_Api.Dto
{
    public class ProfessorDto
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
        public string Formacao { get; set; } = null!;

        public string Experiencia { get; set; } = null!;

        public string Estado { get; set; } = null!;
    }
}
