using System;
using System.Collections.Generic;

namespace LabSchool_Api.Models;

public partial class Aluno: Pessoa
{

    public string SituacaoMatricula { get; set; } = null!;

    public float NotaProcessoSeletivo { get; set; }

    public int TotalDeAtendimentoPedagogicos { get; set; } = 0;

}
