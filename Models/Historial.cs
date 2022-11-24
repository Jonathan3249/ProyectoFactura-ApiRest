using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Historial
{
    public int IdHistorial { get; set; }

    public double Cantidad { get; set; }

    public int IdCliente { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; }
}
