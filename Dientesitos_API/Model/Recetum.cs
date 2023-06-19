using System;
using System.Collections.Generic;

namespace Dientesitos_API.Model;

public partial class Recetum
{
    public int? Cantidad { get; set; }

    public string? Dosis { get; set; }

    public int Idcita { get; set; }

    public int Idmedicamento { get; set; }

    public virtual CitaDental IdcitaNavigation { get; set; } = null!;

    public virtual Medicamento IdmedicamentoNavigation { get; set; } = null!;
}
