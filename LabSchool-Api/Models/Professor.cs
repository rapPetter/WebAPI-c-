using System;
using System.Collections.Generic;

namespace LabSchool_Api.Models;

public partial class Professor:Pessoa
{

    public string FormacaoAcademica { get; set; } = null!;

    public string ExperienciaEmDesenvolvimento { get; set; } = null!;

    public string Estado { get; set; } = null!;

}
