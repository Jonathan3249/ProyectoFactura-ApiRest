using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    public class TipoClientesController : ControllerBase
    {
        private readonly FacturasContext _context;

        public TipoClientesController(FacturasContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListaTipoClientes")]
        public async Task<IActionResult> Lista()
        {
            List<TipoCliente> lista = new List<TipoCliente>();
            try
            {
                lista = await _context.TipoClientes.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCliente>> GetTipoCliente(int id)
        {
            var tipocliente = await _context.TipoClientes.FindAsync(id);

            if (tipocliente == null)
            {
                return NotFound();
            }

            return tipocliente;
        }
    }
}
