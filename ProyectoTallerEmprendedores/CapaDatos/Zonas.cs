using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoTallerEmprendedores.CapaDatos
{
    public class Zonas
    {
        ConexionBD stringdb = new ConexionBD();
        SqlConnection sqlConnection = new SqlConnection();
        public void InsertarZona(int ID, string Nombre)
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlCommand sqlCommand = new SqlCommand("InsertarZonas", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlCommand.Parameters.AddWithValue("@NombreZona", Nombre);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarZona(int ID)
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlCommand sqlCommand = new SqlCommand("EliminarZonas", sqlConnection);
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

        public void ModificarZona(int ID, string Nombre)
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

        public DataTable VisualizarZonas()
        {
            try
            {
                sqlConnection.ConnectionString = stringdb.Cadena();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("VisualizarZonas", sqlConnection);
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
