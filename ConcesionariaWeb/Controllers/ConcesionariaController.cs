using ConcesionariaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace ConcesionariaWeb.Controllers
{
    public class ConcesionariaController : Controller
    {
        private string urlBase = "https://localhost:7061/api/ConcesionariaAPI/";

        public async Task<IActionResult> Index()
        {
            List<Ventas> listaVentas = new List<Ventas>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("Vehiculos");
                string apiResponse = await response.Content.ReadAsStringAsync();
                listaVentas = JsonConvert.DeserializeObject<List<Ventas>>(apiResponse).ToList();
            }
            return View(await Task.Run(() => listaVentas));
        }

        public async Task<IActionResult> Create()
        {
            return View(await Task.Run(() => new Clientes()));

        }

        [HttpPost]
        public async Task<IActionResult> Create(Ventas venta)
        {
            string mensaje = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                StringContent content = new StringContent(JsonConvert.SerializeObject(venta),
                    Encoding.UTF8, "aplication/json");

                HttpResponseMessage response = await client.PostAsync("insertVenta", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;

            }

            ViewBag.mensaje = mensaje;
            return View(await Task.Run(() => venta));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            //redireccion al index de ventas
            if (id == null)
            {
                return RedirectToAction("Index");

            }

            Ventas venta = new Ventas();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                HttpResponseMessage response = await client.GetAsync("getVentas/" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                venta = JsonConvert.DeserializeObject<Ventas>(apiResponse);

            }
            return View(await Task.Run(() => venta));


        }


        [HttpPost]
        public async Task<IActionResult> Edit(Ventas venta)
        {
            string mensaje = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                StringContent content = new StringContent(JsonConvert.SerializeObject(venta),
                     Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("updateVenta", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }

            ViewBag.mensaje = mensaje;
            return View(await Task.Run(() => venta));

        }

    }
}
