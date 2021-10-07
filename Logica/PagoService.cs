using System;
using System.Collections.Generic;
using Datos;
using Entidad;

namespace Logica
{
    public class PagoService
    {
        private ConnectionManager connection;
        private PagoRepository pagoRepository;
        public PagoService(string connectionString)
        {
            connection = new ConnectionManager(connectionString);
            pagoRepository = new PagoRepository(connection);
        }

        public PagoGuardarResponse Guardar(Pago pago)
        {
            try
            {
                connection.Open();
                pagoRepository.Guardar(pago);
                return new PagoGuardarResponse(pago);
            }
            catch (Exception e)
            {
                return new PagoGuardarResponse( "Error al guardar " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public  PagoConsultarResponse Consultar()
        {
            try
            {
                connection.Open();
                List<Pago> pagos= pagoRepository.Consultar();
                return new  PagoConsultarResponse(pagos);
            }
            catch (Exception e)
            {
                return new  PagoConsultarResponse("Error al Guardar" + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }


public class PagoGuardarResponse
{
    public Pago Pago { get; set; }
    public string Mensaje { get; set; }

    public bool Error { get; set; }

    public PagoGuardarResponse(string mensaje)
    {
            Mensaje = mensaje;
            Error = true;
    }
    public PagoGuardarResponse(Pago pago)
    {
            Pago=pago;
            Error = false;
    }
    
    

}

 public class PagoConsultarResponse
    {
        public bool Error { get; set; }
        public List<Pago> Pagos { get; set; }
        public string Mensaje { get; set; }
        public  PagoConsultarResponse (String mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public  PagoConsultarResponse (List<Pago> pagos)
        {
            Pagos=pagos;
            Error = false;
        }
        
    }

}
