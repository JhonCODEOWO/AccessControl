using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoTallerEmprendedores.CapaDatos
{
    public class TipoPosesion
    {
        ConexionBD stringdb = new ConexionBD();
        SqlConnection sqlConnection = new SqlConnection();
        public void InsertarTipoPos(int ID, string Nombre)
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlCommand sqlCommand = new SqlCommand("InsertarTipoPosesion", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlCommand.Parameters.AddWithValue("@Nombre_Tipo", Nombre);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void EliminarTipoPos(int ID)
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlCommand sqlCommand = new SqlCommand("EliminarTipoPosesion", sqlConnection);
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

        public void ModificarTipoPos(int ID, string Nombre)
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlCommand sqlCommand = new SqlCommand("ActualizarTipoPosesion", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlCommand.Parameters.AddWithValue("@Nombre_Tipo", Nombre);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable VisualizarTipoPosesion()
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("VisualizarTipoPosesion", sqlConnection);
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
