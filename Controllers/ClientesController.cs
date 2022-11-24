using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoFactura.Context;
using ProyectoFactura.Models;
using ProyectoFactura.Models.ModelsExt;

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
        [Route("Clientes/{busqueda}")]
        public async Task<IActionResult> BusProductos(string busqueda)
        {
            List<ClientesExt> lista = new List<ClientesExt>();
            try
            {
                lista = await _context.Clientes
                   .Where(p => string.Concat(p.NombreCompleto.ToLower(), p.NumeroContador.ToLower()).Contains(busqueda.ToLower()))
                .Select(p => new ClientesExt()
                {
                    Id = p.IdCliente,
                    Nombre = p.NombreCompleto,
                    Direccion = p.Direccion,
                    Contador = p.NumeroContador,
                    Correo = p.Correo,
                    Telefono = p.Telefono
                }).ToListAsync();


                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);

            }
        }

        [HttpGet]
        [Route("SP")]
        public async Task<ActionResult<List<Cliente>>> ObtenerDatos()
        {
            var result = await _context.Clientes.FromSqlRaw("spDatos").ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("Filtrar")]
        public ActionResult Obtener(string contador)
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                if (contador == null)
                {
                    clientes = _context.Clientes.ToList();
                }

                else
                {
                    clientes = _context.Clientes.Where(x => x.NumeroContador.ToLower().IndexOf(contador)> -1).ToList();

                    SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
                    SqlCommand comando = conexion.CreateCommand();
                    conexion.Open();
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "spDatos";
                    comando.Parameters.Add("@numMedidor", System.Data.SqlDbType.NVarChar,50).Value = contador;
                    SqlDataReader reader = comando.ExecuteReader();
                    while(reader.Read())
                    {
                        Cliente cli = new Cliente();
                    
                        cli.IdCliente = (int)reader["IdCliente"];
                        cli.NombreCompleto = (string)reader["NombreCompleto"];
                        cli.Direccion = (string)reader["Direccion"];
                        cli.Correo = (string)reader["Correo"];
                        cli.NumeroContador = (string)reader["NumeroContador"];
                        cli.Telefono = (string)reader["Telefono"];
                        
                        clientes.Add(cli);
                        



                    }
                    conexion.Close();

                }

                return Ok(contador);

            }
            catch
            {
                return BadRequest("Error");
            }
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
