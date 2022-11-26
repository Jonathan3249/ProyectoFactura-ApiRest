using System;
using System.Collections.Generic;

namespace ProyectoFactura.Models;

public partial class TipoCliente
{
    public int IdTipoCliente { get; set; }

    public string DescripcionTipo { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();
}
