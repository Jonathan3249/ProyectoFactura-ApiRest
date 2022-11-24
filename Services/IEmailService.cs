using Backend.Models;

namespace Backend.Services
{
    public interface IEmailService
    {
        void SendEmail(Correo request);
    }
}
