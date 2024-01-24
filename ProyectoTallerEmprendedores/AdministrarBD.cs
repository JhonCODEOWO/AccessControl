using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTallerEmprendedores.CapaDatos;
using System.Numerics;
using QRCoder;
using System.Drawing.Imaging;
using System.IO;

namespace ProyectoTallerEmprendedores
{
    public partial class AdministrarBD : Form
    {
        public AdministrarBD(Form1 ventana_principal)
        {
            InitializeComponent();
            this.ventana_padre = ventana_principal; //inicializamos al crear la ventana secundaria una referencia a un parametro que se recibe al crearla
        }
        Propietario propietario = new Propietario();
        TipoPropietario tipoPropietario = new TipoPropietario();
        Posesion posesion = new Posesion();
        TipoPosesion tipoPosesion = new TipoPosesion();
        Zonas zonas = new Zonas();
        private Form1 ventana_padre; //Se crea una variable del tipo form1

        string rutaLocalFile = string.Empty;
        string carpetaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImagenesPerfil");
        

        private void AdministrarBD_Load(object sender, EventArgs e)
        {
            //Elementos de tab1 a cargar
            cmbTipoPropietario.DataSource = tipoPropietario.VisualizarTipoPropiedad();
            cmbTipoPropietario.ValueMember = "Nombre_Tipo_Prop";
            dgvPropietarios.DataSource = propietario.VisualizarPropietarios();


            //Elementos de tab2 a cargar
            cmbTipoAutomovil.DataSource = tipoPosesion.VisualizarTipoPosesion();
            cmbTipoAutomovil.ValueMember = "Nombre_Tipo";
            cmbDueño.DataSource = propietario.VisualizarPropietarios();
            cmbDueño.ValueMember = "Nombre";
            cmbZonaEsta.DataSource = zonas.VisualizarZonas();
            cmbZonaEsta.ValueMember = "NombreZona";
            dgvPosesiones.DataSource = posesion.VisualizarPosesiones();

            //Elementos de tab3 a cargar
            dgvTipoVehiculo.DataSource = tipoPosesion.VisualizarTipoPosesion();
            dgvZonas.DataSource = zonas.VisualizarZonas();
        }


        // Código del tab 1 correspondiente a propietarios
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                guardarArchivo();
                int ID = Convert.ToInt32(txtID.Text);
                string Nombre = txtNombre.Text;
                string APaterno = txtAPaterno.Text;
                string AMaterno = txtAMaterno.Text;
                string CURP = txtCurp.Text;
                string RFC = txtRFC.Text;
                string Ubicacion = txtUbicacion.Text;
                string TelefronoPrincipal = txtTelefono1.Text;
                string TelefonoSecundario = txtTelefono2.Text;
                string Correo = txtCorreo.Text;
                int TipoPropietario = cmbTipoPropietario.SelectedIndex + 1;
                string codigo = txtCodigoQR.Text;
                string imgPerfil = lblruta.Text;

                propietario.InsertarPropietario(ID, Nombre, APaterno, AMaterno, CURP, RFC, Ubicacion, TelefronoPrincipal, TelefonoSecundario, Correo, TipoPropietario, codigo, imgPerfil);
                dgvPropietarios.DataSource = null;
                dgvPropietarios.DataSource = propietario.VisualizarPropietarios();

                //cmbDueño.DataSource = null;
                cmbDueño.DataSource = propietario.VisualizarPropietarios();
                cmbDueño.ValueMember = "Nombre";

                BorrrarBox(tabPage1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido procesar la información\nAsegurate de que coloques los datos en un formato correcto y no hayas dejado algún campo vacío", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dgvPropietarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow fila in dgvPropietarios.SelectedRows)
            {
                txtID.Text = fila.Cells[0].Value.ToString();
                txtNombre.Text = fila.Cells[1].Value.ToString();
                txtAPaterno.Text = fila.Cells[2].Value.ToString();
                txtAMaterno.Text = fila.Cells[3].Value.ToString();
                txtCurp.Text = fila.Cells[4].Value.ToString();
                txtRFC.Text = fila.Cells[5].Value.ToString();
                txtUbicacion.Text = fila.Cells[6].Value.ToString();
                txtTelefono1.Text = fila.Cells[7].Value.ToString();
                txtTelefono2.Text = fila.Cells[8].Value.ToString();
                txtCorreo.Text = fila.Cells[9].Value.ToString();
                txtCodigoQR.Text = fila.Cells[11].Value.ToString();
                lblruta.Text = fila.Cells[12].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(dgvPropietarios.Rows[dgvPropietarios.CurrentRow.Index].Cells[0].Value.ToString());
            propietario.EliminarPropietario(id);
            dgvPropietarios.DataSource = null;
            dgvPropietarios.DataSource = propietario.VisualizarPropietarios();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(txtID.Text);
            string Nombre = txtNombre.Text;
            string APaterno = txtAPaterno.Text;
            string AMaterno = txtAMaterno.Text;
            string CURP = txtCurp.Text;
            string RFC = txtRFC.Text;
            string Ubicacion = txtUbicacion.Text;
            string TelefronoPrincipal = txtTelefono1.Text;
            string TelefonoSecundario = txtTelefono2.Text;
            string Correo = txtCorreo.Text;
            int TipoPropietario = cmbTipoPropietario.SelectedIndex + 1;
            string codigo = txtCodigoQR.Text;
            string imgPerfil = lblruta.Text;

            propietario.ModificarPropietario(ID, Nombre, APaterno, AMaterno, CURP, RFC, Ubicacion, TelefronoPrincipal, TelefonoSecundario, Correo, TipoPropietario, codigo, imgPerfil);
            dgvPropietarios.DataSource = null;
            dgvPropietarios.DataSource = propietario.VisualizarPropietarios();
        }

        //Codigo del tab2 referente a las posesiones

        private void btnInsertarPosesion_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(txtID_Pos.Text);
            string Marca = txtMarca.Text;
            string Color = txtColor.Text;
            string Descripcion = txtDescripcion_Pos.Text;
            string Placas = txtPlacas.Text;
            int TipoAuto = cmbTipoAutomovil.SelectedIndex + 1;
            int TipoPropietario = propietario.ID_Propietario(cmbDueño.Text);
            int Zona = cmbZonaEsta.SelectedIndex + 1;

            posesion.InsertarPosesion(ID, Marca, Color, Descripcion, Placas, TipoAuto, TipoPropietario, Zona);
            dgvPosesiones.DataSource = null;
            dgvPosesiones.DataSource = posesion.VisualizarPosesiones();
            //ventana_padre.ActualizarLista(propietario.VisualizarPropietariosSoloNombres()); //Accedemos por medio de la variable a sus métodos y mandamos lo necesario

            
        }

        private void btnActualizarPosesion_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminarPosesion_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(dgvPosesiones.Rows[dgvPosesiones.CurrentRow.Index].Cells[0].Value.ToString());
            posesion.EliminarPosesion(id);
            dgvPosesiones.DataSource = null;
            dgvPosesiones.DataSource = posesion.VisualizarPosesiones();
        }

        //Codigo de tab3

        private void btnInsertarZona_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(txtIDZona.Text);
            string Nombre = txtNombreZona.Text;
            zonas.InsertarZona(ID, Nombre);
            dgvZonas.DataSource = null;
            dgvZonas.DataSource = zonas.VisualizarZonas();

            cmbZonaEsta.DataSource = zonas.VisualizarZonas();
            cmbZonaEsta.ValueMember = "NombreZona";
            BorrrarBox(tabPage3);
        }

        private void btnActualizarZona_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(txtIDZona.Text);
            string Nombre = txtNombreZona.Text;
            zonas.ModificarZona(ID, Nombre);
        }

        private void btnEliminarZona_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(dgvZonas.Rows[dgvZonas.CurrentRow.Index].Cells[0].Value.ToString());
            zonas.EliminarZona(id);
            //dgvZonas.DataSource = null;
            dgvZonas.DataSource = zonas.VisualizarZonas();
        }

        private void btnInsertarTipoPos_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(txtIDTPos.Text);
            string Nombre = txtNombreTPos.Text;
            tipoPosesion.InsertarTipoPos(ID, Nombre);
            dgvTipoVehiculo.DataSource = null;
            dgvTipoVehiculo.DataSource = tipoPosesion.VisualizarTipoPosesion();

            //cmbTipoAutomovil.DataSource = null;
            cmbTipoAutomovil.DataSource = tipoPosesion.VisualizarTipoPosesion();
            cmbTipoAutomovil.ValueMember = "Nombre_Tipo";

            
        }

        private void btnActualizarTipoPos_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(txtIDTPos.Text);
            string Nombre = txtNombreTPos.Text;
            tipoPosesion.ModificarTipoPos(ID, Nombre);
            dgvTipoVehiculo.DataSource = null;
            dgvTipoVehiculo.DataSource = tipoPosesion.VisualizarTipoPosesion();
        }

        private void btnEliminarTipoPos_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(dgvTipoVehiculo.Rows[dgvTipoVehiculo.CurrentRow.Index].Cells[0].Value.ToString());
            tipoPosesion.EliminarTipoPos(id);
            dgvTipoVehiculo.DataSource = null;
            dgvTipoVehiculo.DataSource = tipoPosesion.VisualizarTipoPosesion();
        }

        private void dgvZonas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvZonas.SelectedRows)
            {
                txtIDZona.Text = row.Cells[0].Value.ToString();
                txtNombreZona.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dgvPosesiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPosesiones.SelectedRows)
            {
                txtID_Pos.Text = row.Cells[0].Value.ToString();
                txtMarca.Text = row.Cells[2].Value.ToString();
                txtColor.Text = row.Cells[4].Value.ToString();
                txtDescripcion_Pos.Text = row.Cells[5].Value.ToString();
                txtPlacas.Text = row.Cells[3].Value.ToString();
                cmbTipoAutomovil.Text = row.Cells[1].Value.ToString();
                cmbDueño.Text = row.Cells[6].Value.ToString();
                cmbZonaEsta.Text = row.Cells[7].Value.ToString();
            }
        }

        private void dgvTipoVehiculo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTipoVehiculo.SelectedRows)
            {
                txtIDTPos.Text = row.Cells[0].Value.ToString();
                txtNombreTPos.Text = row.Cells[1].Value.ToString();
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = tabControl1.TabPages[e.Index];

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            // Este sera el rectangulo que se dibujara sobre el titutlo del tab 
            RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);

            // Este sera el color por defecto del tab no seleccionado 
            SolidBrush sb = new SolidBrush(Color.AntiqueWhite);

            // color del tab que se selecciona
            if (tabControl1.SelectedIndex == e.Index)
                sb.Color = Color.Aqua;

            // aplica el color sobre el tabpage actual 
            g.FillRectangle(sb, e.Bounds);

            //escribe el texto que tenia el tab 
            g.DrawString(tp.Text, tabControl1.Font, new SolidBrush(Color.Black), headerRect, sf);
            /*if (e.Index == 0)
            {
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, Font, Brushes.Black, e.Bounds, new StringFormat(StringFormatFlags.NoWrap));*/
        }

        public void BorrrarBox(TabPage tab)
        {
            switch (tab.Name.ToString())
            {
                case "tabPage1":
                    txtID.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtAPaterno.Text = string.Empty;
                    txtAMaterno.Text = string.Empty;
                    txtCurp.Text = string.Empty;
                    txtRFC.Text = string.Empty;
                    txtUbicacion.Text = string.Empty;
                    txtTelefono1.Text = string.Empty;
                    txtTelefono2.Text = string.Empty;
                    txtCorreo.Text = string.Empty;
                    txtCodigoQR.Text = string.Empty;
                    break;

                case "tabPage2":
                    txtID_Pos.Text = string.Empty;
                    txtMarca.Text = string.Empty;
                    txtColor.Text = string.Empty;
                    txtDescripcion_Pos.Text = string.Empty;
                    txtPlacas.Text = string.Empty;
                    break;

                case "tabPage3":
                    txtIDZona.Text = string.Empty;
                    txtNombreZona.Text = string.Empty;
                    txtIDTPos.Text = string.Empty;
                    txtNombreTPos.Text = string.Empty;
                    break;

                default:
                    break;
            }
            Console.WriteLine(tab.Name.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorrrarBox(tabPage1);
        }

        public static Bitmap generarQR(string contenido)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData qRCodeData = generator.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(qRCodeData);
            Bitmap qrCodeImage = code.GetGraphic(10);

            return qrCodeImage;
        }

        public void guardarArchivo()
        {
            string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Códigos qr");
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
                Console.WriteLine("La carpeta ha sido creada");
                Bitmap imagen = generarQR(txtCodigoQR.Text);
                string nombreFichero = "QR_De_" + txtNombre.Text + "_" + txtAPaterno.Text + "_" + txtAPaterno.Text + ".png";

                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Cóigos qr", nombreFichero);
                Console.Write(ruta);
                imagen.Save(ruta, ImageFormat.Png);
            }
            else
            {
                Console.WriteLine("La carpeta existe");
                Bitmap imagen = generarQR(txtCodigoQR.Text);
                string nombreFichero = "QR_De_" + txtNombre.Text + "_" + txtAPaterno.Text + "_" + txtAMaterno.Text + ".png";

                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Códigos qr", nombreFichero);
                Console.Write(ruta);
                imagen.Save(ruta, ImageFormat.Png);
            }
            
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog seleccionarFoto = new OpenFileDialog();
            seleccionarFoto.Title = "Elige una imagen para el usuario";
            seleccionarFoto.Filter = "Imágenes JPG (*.jpg)|*.jpg|Imágenes PNG (*.png)|*.png";
            if (seleccionarFoto.ShowDialog() == DialogResult.OK)
            {
                rutaLocalFile = seleccionarFoto.FileName;
                Image imagen = Image.FromFile(rutaLocalFile);
                pictureFotoP.Image = imagen;
                lblruta.Text = rutaLocalFile;
            }
        }
    }
}
