using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFactura.Context;
using ProyectoFactura.Models;

namespace ProyectoFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacionesController : ControllerBase
    {
        private readonly FacturasContext _context;

        public ObservacionesController(FacturasContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListaObservaciones")]

        public async Task<IActionResult> Lista()
        {
            List<Observacione> lista = new List<Observacione>();
            try
            {
                lista = await _context.Observaciones.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }


    }
}
