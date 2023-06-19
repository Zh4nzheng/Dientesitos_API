using System;
using System.Collections.Generic;

namespace Dientesitos_API.Model;

public partial class MaterialTratamiento
{
    public int? Cantidad { get; set; }

    public int Idtratamiento { get; set; }

    public int Idmaterial { get; set; }

    public virtual MaterialMedico IdmaterialNavigation { get; set; } = null!;

    public virtual Tratamiento IdtratamientoNavigation { get; set; } = null!;
}
