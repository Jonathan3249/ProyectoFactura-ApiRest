using System;
using System.Collections.Generic;

namespace ProyectoFactura.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public int IdTipoCliente { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

    public virtual TipoCliente? IdTipoClienteNavigation { get; set; }  
}
