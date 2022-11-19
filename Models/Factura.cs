using System;
using System.Collections.Generic;

namespace ProyectoFactura.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int IdCliente { get; set; }

    public int IdTarifa { get; set; }

    public int IdObservaciones { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Observacione IdObservacionesNavigation { get; set; } = null!;

    public virtual Tarifa IdTarifaNavigation { get; set; } = null!;
}
