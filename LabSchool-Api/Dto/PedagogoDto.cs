namespace LabSchool_Api.Dto
{
    public class PedagogoDto
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
        public int Atendimentos { get; set; }
    }
}
