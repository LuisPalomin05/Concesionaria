using ConcesionariaAPI.Models;
using ConcesionariaAPI.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConcesionariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcesionariaController : Controller
    {
        public readonly IClientes _cleinteRepo;
        public readonly IVehiculos _vehiculoRepo;
        public readonly IVentas _ventaRepo;
        public readonly IEmpleados _empleadoRepo;

        public ConcesionariaController(IClientes clienteRepo, IVehiculos vehiculoRepo, IVentas ventaRepo, IEmpleados empleadoRepo)
        {
            _cleinteRepo = clienteRepo;
            _vehiculoRepo = vehiculoRepo;
            _ventaRepo = ventaRepo;
            _empleadoRepo = empleadoRepo;
        }

        /* listar elementos */

        [HttpGet("listarClientes")]
        public IActionResult ListarClientes()
        {
            var data = _cleinteRepo.ListarClientes();
            return Ok(data);
        }

        [HttpGet("listarVehiculos")]
        public IActionResult ListarVehiculos()
        {
            var data = _vehiculoRepo.ListarVehiculos();
            return Ok(data);
        }

        [HttpGet("listarVentas")]
        public IActionResult ListarVentas() {
            var data = _ventaRepo.ListarVentas();
            return Ok(data);
        }

        [HttpGet("listarEmpleados")]
        public IActionResult ListarEmpleados()
        {
            var data = _empleadoRepo.ListarEmpleados();
            return Ok(data);
        }




        /* crear elementos */

        [HttpPost("insertarCliente")]
        public IActionResult InsertarCliente(Clientes client)
        {
            var data = _cleinteRepo.InsertarCliente(client);
            return Ok(data);
        }

        [HttpPost("insertarVehiculo")]
        public IActionResult InsertarVehiculo(Vehiculos vehiculo)
        {
            var data = _vehiculoRepo.InsertarVehiculo(vehiculo);
            return Ok(data);
        }

        [HttpPost("insertarEmpleado")]
        public IActionResult InsertarEmpleado(Empleados empleado)
        {
            var data = _empleadoRepo.InsertarEmpleado(empleado);
            return Ok(data);
        }



        }
}
