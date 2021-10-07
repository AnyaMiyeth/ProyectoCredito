using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class PagoRepository
    {
        private readonly SqlConnection _connection;
        public PagoRepository(ConnectionManager connection)
        {
            _connection = connection.connection;

        }

        public void Guardar(Pago pago)
        {
            using(var command=_connection.CreateCommand()){
                command.CommandText = "INSERT INTO pago (Valor,Fecha) VALUES (@Valor,@Fecha)";
                command.Parameters.AddWithValue("@Valor", pago.Valor);
                command.Parameters.AddWithValue("@Fecha", pago.Fecha);
                command.ExecuteNonQuery();
            }

        }
        
        public List<Pago> Consultar()
        {
            List<Pago> pagos=new List<Pago>();
            using(var command= _connection.CreateCommand())
            {
                command.CommandText="Select * from pago";
                var lector=command.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Pago pago = new Pago();
                        pago.Id=(int)lector["Id"];
                        pago.Valor=(decimal)lector["Valor"];
                        pago.Fecha=(DateTime)lector["Fecha"];
                        pagos.Add(pago);
                    }
                }
                
            }
            return pagos;
        }


    }
}
