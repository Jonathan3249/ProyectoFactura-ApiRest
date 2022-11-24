using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifasController : ControllerBase
    {
        private readonly FacturasContext _context;

        public TarifasController(FacturasContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListaTarifas")]

        public async Task<IActionResult> Lista()
        {
            List<Tarifa> lista = new List<Tarifa>();
            try
            {
                lista = await _context.Tarifas.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }
    }
}
