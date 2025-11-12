using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class frm_Ventas : Form
    {
        private NegocioVenta negocioVenta = new NegocioVenta();
        private NegocioTurno negocioTurno = new NegocioTurno();
        private ProductoVenta producto = new ProductoVenta();
        private DataTable TablaDetalle;

        private void Foco() 
        {
            this.ActiveControl = txt_CodBarra;
            txt_CodBarra.Focus();
        }

        public frm_Ventas()
        {
            InitializeComponent();
        }

        private void frm_Ventas_Load(object sender, EventArgs e)
        {            
            Foco();

            CargarListaDetalle();
                       
            if (SessionActual.userAcutual != null)
            {
                try
                {
                    int idTurno = negocioTurno.AbrirTurno(SessionActual.userAcutual.id);
                    SessionActual.idTurnoActual = idTurno;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                lbl_Bienvenida.Text = $"Nombre: {SessionActual.userAcutual.nombre}";
                lbl_TipoUser.Text = $"Tipo Usuario: {SessionActual.userAcutual.rol}";
            }

            lbl_Bienvenida.Visible = true;
            lbl_TipoUser.Visible = true;
        }

        private void CargarListaDetalle()
        {
            CrearTablaDetalle();
        }

        private void CrearTablaDetalle()
        {
            TablaDetalle = new DataTable();
            TablaDetalle.Columns.Add("id", typeof(int));
            TablaDetalle.Columns.Add("descripcion_P", typeof(string));
            TablaDetalle.Columns.Add("id_Marca", typeof(int));
            TablaDetalle.Columns.Add("descripcion_M", typeof(string));
            TablaDetalle.Columns.Add("Cantidad", typeof(decimal));
            TablaDetalle.Columns.Add("PrecioUnitario", typeof(decimal));
            TablaDetalle.Columns.Add("Subtotal", typeof(decimal));
            TablaDetalle.Columns.Add("Stock_min", typeof(decimal)); // nuevo
            TablaDetalle.Columns.Add("Stock_actual", typeof(decimal)); // nuevo

            dgv_Principal.DataSource = TablaDetalle;
            FormatoDetalle();
        }

        private void FormatoDetalle()
        {
            dgv_Principal.Columns["id"].Visible = false;
            dgv_Principal.Columns["id_Marca"].Visible = false;
            dgv_Principal.Columns["Stock_min"].Visible = false;
            dgv_Principal.Columns["Stock_actual"].Visible = false;

            dgv_Principal.Columns["descripcion_P"].Width = 250;
            dgv_Principal.Columns["descripcion_P"].HeaderText = "DESCRIPCION";
            dgv_Principal.Columns["descripcion_M"].Width = 180;
            dgv_Principal.Columns["descripcion_M"].HeaderText = "MARCA";
            dgv_Principal.Columns["Cantidad"].Width = 90;
            dgv_Principal.Columns["Cantidad"].HeaderText = "CANTIDAD";
            dgv_Principal.Columns["PrecioUnitario"].Width = 100;
            dgv_Principal.Columns["PrecioUnitario"].HeaderText = "PRECIO";
            dgv_Principal.Columns["Subtotal"].Width = 120;
            dgv_Principal.Columns["Subtotal"].HeaderText = "SUB TOTAL";

            dgv_Principal.Columns["descripcion_P"].ReadOnly = true;
            dgv_Principal.Columns["descripcion_M"].ReadOnly = true;
            dgv_Principal.Columns["PrecioUnitario"].ReadOnly = true;
            dgv_Principal.Columns["Subtotal"].ReadOnly = true;


        }

        private void timer_Venta_Tick(object sender, EventArgs e)
        {
            lbl_Fecha.Text = DateTime.Now.ToLongDateString();
            lbl_Hora.Text = DateTime.Now.ToLongTimeString();
        }

        private decimal ObtenerPrecio(ProductoVenta producto)
        {
            if (rdb_PrecioNoche.Checked)
                return producto.precioNoche;

            return producto.precioDia;
        }

        private void AgregarOActualizarProducto(ProductoVenta prod)
        {
            DataRow filaExistente = null;

            foreach (DataRow fila in TablaDetalle.Rows)
            {
                if ((int)fila["id"] == prod.id)
                {
                    filaExistente = fila;
                    break;
                }
            }

            if (filaExistente != null) 
            {
                decimal cantidad = (decimal)filaExistente["Cantidad"] + 1;

                if (cantidad > prod.stock.stock_actual) 
                {
                    MessageBox.Show("No hay suficiente stock para este producto", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                filaExistente["Cantidad"] = cantidad;
                filaExistente["Subtotal"] = cantidad * (decimal)filaExistente["PrecioUnitario"];

                if (prod.stock.stock_actual - cantidad <= prod.stock_Min)
                {
                    MessageBox.Show("Este producto ha llegando al stock minimo", "Aviso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                decimal precio = ObtenerPrecio(prod);

                DataRow row = TablaDetalle.NewRow();
                row["id"] = prod.id;
                row["descripcion_P"] = prod.descripcion;
                row["id_Marca"] = prod.marca.id;
                row["descripcion_M"] = prod.marca.descripcion;
                row["Cantidad"] = 1;
                row["PrecioUnitario"] = precio;
                row["Subtotal"] = precio;
                row["Stock_min"] = prod.stock_Min;
                row["Stock_actual"] = prod.stock.stock_actual;

                TablaDetalle.Rows.Add(row);
            }
        }

        private void ProcesarCodigoBarras(string codBarra)
        {
            if (!rdb_PrecioDia.Checked && !rdb_PrecioNoche.Checked)
            {
                MessageBox.Show("Debe seleccionar primero el modo de Turno (Día o Noche).", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(codBarra)) return;

            ProductoVenta prod = negocioVenta.BuscarProductoPorCodigo(codBarra);

            if (prod != null && prod.id > 0)
            {                
                AgregarOActualizarProducto(prod);
            }
            else
            {
                MessageBox.Show("Producto no encontrado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_CodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ProcesarCodigoBarras(txt_CodBarra.Text.Trim());
                txt_CodBarra.Clear();
                CalcularTotalDetalle();
            }
        }

        private void CalcularTotalDetalle()
        {
            decimal totalImporte = 0;

            if (dgv_Principal.Rows.Count == 0)
            {
                totalImporte = 0;
            }
            else
            {
                TablaDetalle.AcceptChanges();
                foreach (DataRow fila in TablaDetalle.Rows)
                {
                    totalImporte = totalImporte + Convert.ToDecimal(fila["Subtotal"]);
                }

                txt_Total.Text = Convert.ToString(totalImporte);
            }
        }

        private void dgv_Principal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dgv_Principal.EndEdit(); 
            TablaDetalle.AcceptChanges();

            DataRow fila = (DataRow)TablaDetalle.Rows[e.RowIndex];
            decimal cantidad = Convert.ToDecimal(fila["Cantidad"]);
            decimal precio = Convert.ToDecimal(fila["PrecioUnitario"]);
            decimal stock_Acutual = Convert.ToDecimal(fila["Stock_actual"]);
            decimal stock_Min = Convert.ToDecimal(fila["Stock_min"]);

            if (cantidad > stock_Acutual)
            {
                MessageBox.Show("No hay suficiente stock para este producto", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            fila["Subtotal"] = decimal.Round(cantidad * precio, 2).ToString("N2");

            if (stock_Acutual - cantidad <= stock_Min)
            {
                MessageBox.Show("Este producto ha llegando al stock minimo", "Aviso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CalcularTotalDetalle();
            Foco();
        }

        private void CalcularVuelto()
        {
            decimal total = 0;
            decimal efectivo = 0;

            decimal.TryParse(txt_Total.Text, out total);
            decimal.TryParse(txt_Efectivo.Text, out efectivo);

            decimal vuelto = efectivo - total;

            if (vuelto >= 0)
                txt_Vuelto.Text = vuelto.ToString("0.00");
            else
                txt_Vuelto.Text = "0.00";
        }

        private void txt_Efectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                if (!decimal.TryParse(txt_Efectivo.Text, out decimal efectivo))
                    efectivo = 0;

                if (!decimal.TryParse(txt_Total.Text, out decimal total))
                    total = 0;

                if (efectivo < total)
                {
                    MessageBox.Show("El efectivo no puede ser menor al total.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Efectivo.Text = "";
                    txt_Vuelto.Text = "0.00";
                    txt_Efectivo.Focus();
                    return;
                }

                CalcularVuelto();
            }
        }

        private void btn_Quitar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.Rows.Count > 0)
            {
                if (dgv_Principal.CurrentRow != null)
                {
                    dgv_Principal.Rows.Remove(dgv_Principal.CurrentRow);
                    dgv_Principal.Refresh();
                    TablaDetalle.AcceptChanges();
                    CalcularTotalDetalle();                   
                    Foco();
                }
            }

            txt_Efectivo.Text = "";
            txt_Vuelto.Text = "";
            txt_Total.Text = "";
        }

        private void btn_PagoEfectivo_Click(object sender, EventArgs e)
        {
            if (TablaDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto al detalle.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Total.Text) || Convert.ToDecimal(txt_Total.Text) <= 0)
            {
                MessageBox.Show("El total no puede estar vacío o en cero.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Venta venta = new Venta();
            venta.usuario.id = SessionActual.userAcutual.id;
            venta.turno.id = (int)SessionActual.idTurnoActual;
            venta.fecha = DateTime.Now;
            venta.totalImporte = Convert.ToDecimal(txt_Total.Text);

            DataTable tablaSP = ConvertirTablaParaSP(TablaDetalle);
            int idVenta = negocioVenta.AgregarVentaConDetalles(venta, tablaSP);

            MessageBox.Show("Venta registrada correctamente con ID: " + idVenta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TablaDetalle.Clear();
            txt_Efectivo.Text = "";
            txt_Vuelto.Text = "";
            txt_Total.Text = "";
           
            Foco();
        }

        private void btn_PagoQr_Click(object sender, EventArgs e)
        {
            if (TablaDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto al detalle.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Total.Text) || Convert.ToDecimal(txt_Total.Text) <= 0)
            {
                MessageBox.Show("El total no puede estar vacío o en cero.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = Convert.ToDecimal(txt_Total.Text);

            NegocioMercadoPagoQR negocioQR = new NegocioMercadoPagoQR();
            string referencia = $"venta_{DateTime.Now.Ticks}";

            try
            {
                string qrData = negocioQR.CrearQR(total, referencia);

                frm_PagoQR frmQR = new frm_PagoQR(qrData, total);
                frmQR.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable ConvertirTablaParaSP(DataTable tablaDetalle)
        {
            DataTable tablaSP = new DataTable();
            tablaSP.Columns.Add("id_Producto", typeof(int));
            tablaSP.Columns.Add("id_Marca", typeof(int));
            tablaSP.Columns.Add("Cantidad", typeof(decimal));
            tablaSP.Columns.Add("PrecioUnitario", typeof(decimal));
            tablaSP.Columns.Add("Subtotal", typeof(decimal));

            foreach (DataRow fila in tablaDetalle.Rows)
            {
                int idProducto = Convert.ToInt32(fila["id"]);
                int idMarca = Convert.ToInt32(fila["id_Marca"]);
                decimal cantidad = Convert.ToDecimal(fila["Cantidad"]);
                decimal precio = Convert.ToDecimal(fila["PrecioUnitario"]);
                decimal subtotal = Convert.ToDecimal(fila["Subtotal"]);

                tablaSP.Rows.Add(idProducto, idMarca, cantidad, precio, subtotal);
            }

            return tablaSP;
        }

        private void dgv_Principal_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_Principal.CurrentCell.ColumnIndex == 4)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(SoloNumeros_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
                }
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            TextBox txt = sender as TextBox;
            if (e.KeyChar == ',' && txt.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void rdb_PrecioDia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_PrecioDia.Checked)
            {
                MessageBox.Show("Modo Turno Día activado");                
                Foco();
            }
        }

        private void rdb_PrecioNoche_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_PrecioNoche.Checked)
            {
                MessageBox.Show("Modo Turno Noche activado");                
                Foco();
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            if (SessionActual.userAcutual != null)
            {
                try
                {
                    Turno turno = negocioTurno.CerrarTurno((int)SessionActual.idTurnoActual, DateTime.Now);

                    if (turno != null)
                    {
                        frm_ResumenTurno resumen = new frm_ResumenTurno(turno, SessionActual.userAcutual.nombre);
                        resumen.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            SessionActual.CerrarSession();
            Close();
        }
    }
}
