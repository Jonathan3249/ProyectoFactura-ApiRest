using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Observacione
{
    public int IdObservaciones { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();
}
