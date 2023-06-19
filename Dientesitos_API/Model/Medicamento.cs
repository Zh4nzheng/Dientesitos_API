using System;
using System.Collections.Generic;

namespace Dientesitos_API.Model;

public partial class Medicamento
{
    public int Idmedicamento { get; set; }

    public string? Descripcion { get; set; }

    public string? UnidadMedida { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Recetum> Receta { get; set; } = new List<Recetum>();
}
