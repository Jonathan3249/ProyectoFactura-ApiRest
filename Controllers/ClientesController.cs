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
    public class ClientesController : ControllerBase
    {
        private readonly FacturasContext _context;

        public ClientesController(FacturasContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListaCliente")]

        public async Task<IActionResult> Lista()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                lista = await _context.Clientes.ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }



        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Cliente request)
        {
            try
            {
                await _context.Clientes.AddAsync(request);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Cliente request)
        {
            try
            {

                _context.Clientes.Update(request);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Borrar/{id:int}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {


            var tipoUsuarios = await _context.Clientes.FindAsync(id);
            if (tipoUsuarios == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not found");
            }




            _context.Clientes.Remove(tipoUsuarios);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
