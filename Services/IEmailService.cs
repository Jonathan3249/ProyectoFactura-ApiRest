using ProyectoFactura.Models;

namespace ProyectoFactura.Services
{
    public interface IEmailService
    {
        void SendEmail(Correo request);
    }
}
