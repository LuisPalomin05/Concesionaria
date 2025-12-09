using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Concesionaria.Models;
using Concesionaria.Repositorio.DAO;
using Concesionaria.Repositorio.Interfaces;

namespace Concesionaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcesionarioAPIController : Controller
    {
        [HttpGet("getClientes")]
        public async Task<ActionResult<List<Clientes>>> getClientes()
        {
            var list = await Task.Run(() => new clientesDAO().GetClientes());
            return Ok(list);
        }

        [HttpGet("getVehiculos")]
        public async Task<ActionResult<List<Vehiculos>>> getVehiculos()
        {
            var list = await Task.Run(() => new vehiculosDAO().GetVehiculos());
            return Ok(list);
        }

        [HttpGet("getVentas")]
        public async Task<ActionResult<List<Ventas>>> getVentas()
        {
            var list = await Task.Run(() => new ventasDAO().GetVentas());
            return Ok(list);
        }

        [HttpPost("insertCliente")]
        public async Task<ActionResult> addCliente([FromBody] Clientes cliente)
        {
            await Task.Run(() => new clientesDAO().insertClientes(cliente));
            return Ok();
        }

        [HttpPost("insertVehiculo")]
        public async Task<ActionResult> addVehiculo([FromBody] Vehiculos vehiculo)
        {
            await Task.Run(() => new vehiculosDAO().insertVehiculos(vehiculo));
            return Ok();
        }
        [HttpPost("insertVenta")]
        public async Task<ActionResult> addVenta([FromBody] Ventas venta)
        {
            await Task.Run(() => new ventasDAO().insertVentas(venta));
            return Ok();
        }


        [HttpPut("updateVenta")]
        public async Task<ActionResult> putVenta([FromBody] Ventas venta)
        {
            await Task.Run(() => new ventasDAO().updateVentas(venta));
            return Ok();
        }

    }
}
