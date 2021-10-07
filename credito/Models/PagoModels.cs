using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;

namespace credito.Models
{
    public class PagoInputModel
    {
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class PagoViewModel : PagoInputModel
    {
        public int Id { get; set; }
        public PagoViewModel(Pago pago)
        {
            Id = pago.Id;
            Valor = pago.Valor;
            Fecha = pago.Fecha;
        }

    }



}