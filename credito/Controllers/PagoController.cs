using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using credito.Models;
using Entidad;

namespace credito.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {
        private IConfiguration _configuration;
        private PagoService pagoService;
        public PagoController(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            pagoService = new PagoService(connectionString);
        }

    [HttpPost]
        public ActionResult<Pago> Guardar(PagoInputModel pagoInput)
        {   var pago = MapearPago(pagoInput);
            var respuesta=pagoService.Guardar(pago);
            if(respuesta.Error){
                return BadRequest(respuesta.Mensaje);
            }
            return Ok(pago);
        }
        private Pago MapearPago(PagoInputModel pagoInput)
        {
            var pago = new Pago();
            pago.Valor = pagoInput.Valor;
            pago.Fecha = pagoInput.Fecha;
            return pago;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PagoViewModel>> Consultar()
        {
            var respuesta = pagoService.Consultar();
            if(respuesta.Error)
            {
                return BadRequest(respuesta.Mensaje);
            }
            return Ok(respuesta.Pagos.Select(p => new PagoViewModel(p)));

        }
    }
}