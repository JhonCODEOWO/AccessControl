using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProyectoTallerEmprendedores.CapaDatos
{
    public class Posesion
    {
        SqlConnection sqlConnection = new SqlConnection();
        ConexionBD stringbd = new ConexionBD();
        public void InsertarPosesion(int ID, string Marca, string Color, string Descripcion, string Placas, int Tipo, int Dueño, int Zona)
        {
            try
            {
                sqlConnection.ConnectionString = stringbd.Cadena();
                SqlCommand sqlCommand = new SqlCommand("InsertarPosesion", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlCommand.Parameters.AddWithValue("@Marca", Marca);
                sqlCommand.Parameters.AddWithValue("@Color", Color);
                sqlCommand.Parameters.AddWithValue("@Descripción", Descripcion);
                sqlCommand.Parameters.AddWithValue("@Placas", Placas);
                sqlCommand.Parameters.AddWithValue("@Tipo", Tipo);
                sqlCommand.Parameters.AddWithValue("@Dueño", Dueño);
                sqlCommand.Parameters.AddWithValue("@Zona", Zona);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Se ha añadido el registro");
            }
            catch (Exception ex)
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void EliminarPosesion(int ID)
        {
            try
            {
                sqlConnection.ConnectionString = stringbd.Cadena();
                SqlCommand sqlCommand = new SqlCommand("EliminarPosesion", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Dato eliminado");
            }
            catch (Exception ex)
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void ModificarPosesion(int ID, string Marca, string Color, string Descripcion, string Placas, int Tipo, int Dueño, int Zona)
        {
            try
            {
                sqlConnection.ConnectionString = stringbd.Cadena();
                SqlCommand sqlCommand = new SqlCommand("ActualizarPosesion", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlCommand.Parameters.AddWithValue("@Marca", Marca);
                sqlCommand.Parameters.AddWithValue("@Color", Color);
                sqlCommand.Parameters.AddWithValue("@Descripcion", Descripcion);
                sqlCommand.Parameters.AddWithValue("@Placas", Placas);
                sqlCommand.Parameters.AddWithValue("@Descripcion", Descripcion);
                sqlCommand.Parameters.AddWithValue("@Tipo", Tipo);
                sqlCommand.Parameters.AddWithValue("@Dueño", Dueño);
                sqlCommand.Parameters.AddWithValue("@Zona", Zona);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Se ha añadido el registro");
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable VisualizarPosesiones()
        {
            try
            {
                sqlConnection.ConnectionString = stringbd.Cadena();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("VisualizarPosesiones", sqlConnection);
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
