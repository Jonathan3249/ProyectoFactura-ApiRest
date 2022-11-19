using System;
using System.Collections.Generic;

namespace ProyectoFactura.Models;

public partial class Tarifa
{
    public int IdTarifa { get; set; }

    public string? TipoTarifa { get; set; }

    public double? Precio { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();
}
