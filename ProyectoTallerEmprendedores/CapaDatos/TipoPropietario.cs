using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoTallerEmprendedores.CapaDatos
{
    public class TipoPropietario
    {
        SqlConnection sqlConnection = new SqlConnection();
        ConexionBD stringdb = new ConexionBD();
        public void InsertarTipoProp(int ID, string Nombre)
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlCommand sqlCommand = new SqlCommand("InsertarTipoPropietario", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarTipoProp(int ID)
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlCommand sqlCommand = new SqlCommand("EliminarTipoPropietario");
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ModificarTipoProp(int ID, string Nombre)
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlCommand sqlCommand = new SqlCommand("ActualizarTipoPropietario", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable VisualizarTipoPropiedad()
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("VisualizarTipoPropietario", sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                dataAdapter = null;
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
