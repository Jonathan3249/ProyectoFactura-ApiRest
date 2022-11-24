using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using ProyectoFactura.Models;
using ProyectoFactura.Services;

namespace ProyectoFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreoController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public CorreoController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("Guardar")]
        public  IActionResult SendEmail(Correo request)
        {
            try
            {
                _emailService.SendEmail(request);
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
