using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Windows.Forms;

namespace ProyectoTallerEmprendedores.CapaDatos
{
    public class Propietario
    {
        ConexionBD cadena = new ConexionBD();
        SqlConnection sqlConnection = new SqlConnection();
        public void InsertarPropietario(int ID, string Nombre, string APaterno, string AMaterno, string CURP, string RFC, string Ubicacion, string TelefronoPrincipal, string TelefonoSecundario, string Correo, int TipoPropietario, string codigo, string imgPerfil)
        {
            try
            {
                sqlConnection.ConnectionString = cadena.Cadena();
                SqlCommand sqlCommand = new SqlCommand("InsertarPropietario", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
                sqlCommand.Parameters.AddWithValue("@A_Materno", AMaterno);
                sqlCommand.Parameters.AddWithValue("@A_Paterno", APaterno);
                sqlCommand.Parameters.AddWithValue("@CURP", CURP);
                sqlCommand.Parameters.AddWithValue("@RFC", RFC);
                sqlCommand.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                sqlCommand.Parameters.AddWithValue("@TelefonoPrincipal", TelefronoPrincipal);
                sqlCommand.Parameters.AddWithValue("@TelefonoSecundario", TelefonoSecundario);
                sqlCommand.Parameters.AddWithValue("@CorreoElectronico", Correo);
                sqlCommand.Parameters.AddWithValue("@TipoPropietario", TipoPropietario);
                sqlCommand.Parameters.AddWithValue("@Codigo", codigo);
                sqlCommand.Parameters.AddWithValue("@ImagenPerfil", imgPerfil);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            
        }

        public void EliminarPropietario(int ID)
        {
            try
            {
                sqlConnection.ConnectionString = cadena.Cadena();
                SqlCommand sqlCommand = new SqlCommand("EliminarPropietario", sqlConnection);
                sqlCommand.CommandTimeout = 5;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Registro eliminado");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void ModificarPropietario(int ID, string Nombre, string APaterno, string AMaterno, string CURP, string RFC, string Ubicacion, string TelefronoPrincipal, string TelefonoSecundario, string Correo, int TipoPropietario,string codigo, string imgPerfil)
        {
            sqlConnection.ConnectionString = cadena.Cadena();
            SqlCommand sqlCommand = new SqlCommand("ActualizarPropietario", sqlConnection);
            sqlCommand.CommandTimeout = 5;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", ID);
            sqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
            sqlCommand.Parameters.AddWithValue("@A_Materno", AMaterno);
            sqlCommand.Parameters.AddWithValue("@A_Paterno", APaterno);
            sqlCommand.Parameters.AddWithValue("@CURP", CURP);
            sqlCommand.Parameters.AddWithValue("@RFC", RFC);
            sqlCommand.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            sqlCommand.Parameters.AddWithValue("@TelefonoPrincipal", TelefronoPrincipal);
            sqlCommand.Parameters.AddWithValue("@TelefonoSecundario", TelefonoSecundario);
            sqlCommand.Parameters.AddWithValue("@CorreoElectronico", Correo);
            sqlCommand.Parameters.AddWithValue("@TipoPropietario", TipoPropietario);
            sqlCommand.Parameters.AddWithValue("@Codigo", codigo);
            sqlCommand.Parameters.AddWithValue("@ImagenPerfil", imgPerfil);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public DataTable VisualizarPropietarios()
        {
            try
            {
                sqlConnection.ConnectionString = cadena.Cadena();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("VisualizarPropietarios", sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                dataAdapter = null;
                return data;
            }
            catch (Exception ex)
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataTable VisualizarPropietariosSoloNombres(string codigo)
        {
            try
            {
                sqlConnection.ConnectionString = cadena.Cadena();
                SqlCommand sqlCommand = new SqlCommand("ListaIdentificacion", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Codigo", codigo);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                //dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                dataAdapter = null;
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int ID_Propietario(string Nombre)
        {
            try
            {
                int id = 0;
                sqlConnection.ConnectionString = cadena.Cadena();
                SqlCommand sqlCommand = new SqlCommand("EncontrarIDProp", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Nombre", Nombre);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                dataAdapter = null;

                foreach (DataRow row in data.Rows)
                {
                    id = Convert.ToInt16(row[0].ToString());
                }
                return id;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable ObtenerAparcamiento(string codigo)
        {
            try
            {
                sqlConnection.ConnectionString = cadena.Cadena();
                SqlCommand sqlCommand = new SqlCommand("ObetenerAparcamiento", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Codigo", codigo);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                dataAdapter = null;
                if (dataTable.Rows.Count > 0)
                {
                    Console.WriteLine("La tabla tiene datos");
                    return dataTable;
                }
                else
                {
                    Console.WriteLine("No se ha recibido nada");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
