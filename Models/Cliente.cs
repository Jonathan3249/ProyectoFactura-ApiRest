using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCompleto { get; set; }

    public string Direccion { get; set; }

    public string Telefono { get; set; }

    public int IdTipoCliente { get; set; }

    public string NumeroContador { get; set; }

    public string Correo { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

    public virtual ICollection<Historial> Historials { get; } = new List<Historial>();

    public virtual TipoCliente IdTipoClienteNavigation { get; set; }
}
