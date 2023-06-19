using System;
using System.Collections.Generic;

namespace Dientesitos_API.Model;

public partial class MaterialMedico
{
    public int Idmaterial { get; set; }

    public string? Descripcion { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<MaterialTratamiento> MaterialTratamientos { get; set; } = new List<MaterialTratamiento>();
}
