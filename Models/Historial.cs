namespace ProyectoFactura.Models
{
    public class Historial
    {
        public int? IdHistorial { get; set; }

        public float? Cantidad { get; set; }

        public int? IdCliente { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
    }
}
