using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ProyectoTallerEmprendedores.CapaDatos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace ProyectoTallerEmprendedores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Propietario propietario = new Propietario();
        private void lblAdministrar_Click(object sender, EventArgs e)
        {
            AdministrarBD ventana = new AdministrarBD(this); //Al crear el objeto mandamos this "esta" ventana como el párametro que necesitamos
            //AdministrarBD administrarBD = new AdministrarBD();
            ventana.Show();
        }

        private void lblAdministrar_MouseEnter(object sender, EventArgs e)
        {
            lblAdministrar.BackColor = ColorTranslator.FromHtml("#ff6768");
        }

        private void lblAdministrar_MouseLeave(object sender, EventArgs e)
        {
            lblAdministrar.BackColor = Color.Transparent;
        }

        public void LlenarLista(DataTable tabla) {
            System.Drawing.Image imagen;
        //{
        //    var Lista = listPersonal;

        //    listPersonal.Items.Clear();
        //    Lista.Columns.Clear();
        //    Lista.View = View.Details;
        //    Lista.GridLines = false;
        //    Lista.FullRowSelect = true;
        //    Lista.Scrollable = true;
        //    Lista.HideSelection = false;
        //    //Lista.HeaderStyle = ColumnHeaderStyle.None;
        //    foreach (DataColumn column in tabla.Columns)
        //    {
        //        int longitud = column.ColumnName.Length;
        //        listPersonal.Columns.Add(column.ColumnName, 140);
        //    }

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                DataRow dr = tabla.Rows[i];
                //ListViewItem list = new ListViewItem(dr["Nombre"].ToString());
                //list.SubItems.Add(dr["Apellido Paterno"].ToString());
                //list.SubItems.Add(dr["Apellido Materno"].ToString());
                //list.SubItems.Add(dr["Tipo de persona"].ToString());
                //list.SubItems.Add(dr["Zona"].ToString());
                //listPersonal.Items.Add(list);
                lblNombreCompleto.Text = dr["Nombre"].ToString() + " " + dr["Apellido Paterno"] + " " + dr["Apellido Materno"];
                lblTipo.Text = dr["Tipo de persona"].ToString();
                lblZona.Text = dr["Zona"].ToString();
                imagen = System.Drawing.Image.FromFile(dr["ImagenPerfil"].ToString());
                pictureImagen.Image = imagen;
            }

        //    //Lista.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           

        }

        private void listPersonal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                //string Nombre = listPersonal.Items[listPersonal.SelectedIndices[0]].SubItems[0].Text;
                //string APaterno = listPersonal.Items[listPersonal.SelectedIndices[0]].SubItems[1].Text;
                //string AMaterno = listPersonal.Items[listPersonal.SelectedIndices[0]].SubItems[2].Text;
                //Console.WriteLine(Nombre + APaterno + AMaterno);

                
                //foreach (DataRow row in propietario.ObtenerAparcamiento(Nombre, APaterno, AMaterno).Rows)
                //{
                //    dataGridView1.Rows.Add(row.ItemArray);
                //}
                //listPersonal.Items.Remove(listPersonal.SelectedItems[0]);
            }
        }

        public void ActualizarLista(DataTable tabla)
        {
            //LlenarLista(tabla);
        }

        public String leerQR(string ruta)
        {
            BarcodeReader lector = new BarcodeReader();
            lector.AutoRotate = true;
            lector.Options = new DecodingOptions { TryHarder = true };
            Result resultado = lector.Decode(new Bitmap(ruta));

            if (resultado != null)
            {
                return resultado.Text;
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rutaQR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Códigos qr");
            if (!Directory.Exists(rutaQR))
            {
                MessageBox.Show("Aún no has agregado usuarios o generado un código qr de alguno de ellos", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            openFileDialog1.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Códigos qr");
            openFileDialog1.Title = "Selecciona una imágen con código QR";
            openFileDialog1.Filter = "Imágenes png (*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = openFileDialog1.FileName;
                //Image imagen = Image.FromFile(ruta);
                //pictureImagen.Image = imagen;
                Console.WriteLine(leerQR(ruta));
                if (propietario.VisualizarPropietariosSoloNombres(leerQR(ruta)).Rows.Count == 0)
                {
                    MessageBox.Show("El usuario del cual has escaneado el código qr no tiene aún una posesión asignada\nverifica en la administración de datos en la pestaña de posesiones el usuario tenga algo asignado y vuelve a intentarlo", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    pictureImagen.Image = null;
                }
                else
                {
                    lblCodigo.Text = leerQR(ruta);
                    LlenarLista(propietario.VisualizarPropietariosSoloNombres(leerQR(ruta)));
                }
                
            }
            
        }

        private void btnAparcar_Click(object sender, EventArgs e)
        {
            if (lblNombreCompleto.Text == "" || lblTipo.Text == "" || lblZona.Text == "")
            {
                MessageBox.Show("*¡No puedes aparcar algo que no has escaneado!*\n1. Haz clic en seleccionar qr\n2. Haz clic en aparcar", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                string codigo = lblCodigo.Text;
                foreach (DataRow row in propietario.ObtenerAparcamiento(codigo).Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                    ReiniciarElementosInfo();
                }
            }
            
        }

        public void ReiniciarElementosInfo()
        {
            pictureImagen.Image = null;
            lblNombreCompleto.Text = string.Empty;
            lblCodigo.Text = string.Empty;
            lblTipo.Text = string.Empty;
            lblZona.Text = string.Empty;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            try
            {
                string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Reportes");
                if (!Directory.Exists(rutaCarpeta))
                {
                    Console.WriteLine("La carpeta no existia");
                    Directory.CreateDirectory(rutaCarpeta);
                }
                else
                {
                    Console.WriteLine("La carpeta si existia");
                }
                string fecha = DateTime.Now.ToString("yyMMdd_HHmmss");
                string nombreReporte = fecha + "_Reporte.pdf";
                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Reportes", nombreReporte);
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();
                //doc.Add(new Paragraph("Reporte de entradas " + DateTime.Today.ToString()));
                doc.Add(new Paragraph("Reporte de entradas " + DateTime.Today.ToString()));
                doc.Add(new Paragraph("\n"));
                PdfPTable pdfPTable = new PdfPTable(dataGridView1.Columns.Count);
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    Console.WriteLine(dataGridView1.Columns[i].HeaderText);
                    pdfPTable.AddCell(dataGridView1.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            Console.WriteLine(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            pdfPTable.AddCell(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            Console.WriteLine("No hay datos");
                        }
                    }
                }

                doc.Add(pdfPTable);
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnVerReportes_Click(object sender, EventArgs e)
        {
            string rutaReportes = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Reportes");
            if (!Directory.Exists(rutaReportes))
            {
                MessageBox.Show("Aún no has generado reportes, por lo que el directorio de almacenamiento no existe", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                Process.Start("explorer.exe", rutaReportes);
            }
        }
    }
}
