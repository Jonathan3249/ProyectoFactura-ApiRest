using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProyectoFactura.Context;
using ProyectoFactura.Models;
using ProyectoFactura.Models.ModelsExt;

namespace ProyectoFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialsController : ControllerBase
    {
        private readonly FacturasContext _context;

        public HistorialsController(FacturasContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{recibir}")]
        public async Task<ActionResult<List<Historial>>> ObtenerDatos(int recibir)
        {
          
            var result = await _context.Historials.FromSqlRaw($"exec spUsado {recibir}").ToListAsync();
            double suma = 0;
            foreach(var historial in result)
            {
                suma = result.Sum(historial => historial.Cantidad);
            }

            List<SumaCantidad> datoNuevo = new List<SumaCantidad>()
            {
                new SumaCantidad() {Cantidad = suma}
            };


            return Ok(datoNuevo);
        }

        // GET: api/Historials/5
        [HttpGet("Historial/{id}")]
        public async Task<ActionResult<Historial>> GetHistorial(int id)
        {
            var historial = await _context.Historials.FindAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

       
        private bool HistorialExists(int id)
        {
            return _context.Historials.Any(e => e.IdCliente == id);
        }
    }
}
