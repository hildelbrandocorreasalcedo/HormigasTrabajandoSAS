using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace GUINominas
{
    public partial class FrmConsulta : Form
    {

        HormigaService servicioempleado = new HormigaService();
        IReceptor frmReceptor;

        public FrmConsulta()
        {
            InitializeComponent();
        }
        public FrmConsulta(IReceptor iReceptor)
        {
            InitializeComponent();
            frmReceptor = iReceptor;
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            List<Empleado> empleados = new List<Empleado>();
            empleados = servicioempleado.Consultar();
            dtempleados.DataSource = empleados;
        }

        private void dtempleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Empleado empleado = (Empleado)dtempleados.CurrentRow.DataBoundItem;
            if (frmReceptor != null)
            {
                frmReceptor.Recibir(empleado);
                this.Hide();
            }
        }

        public void LlenarTabla()
        {
            List<Empleado> empleados = new List<Empleado>();
            empleados = servicioempleado.Consultar();
            dtempleados.DataSource = empleados;
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (TxtBusqueda.Text != "")
            {
                dtempleados.CurrentCell = null;
                foreach (DataGridViewRow r in dtempleados.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dtempleados.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if (c.Value.ToString().ToUpper().IndexOf(TxtBusqueda.Text.ToUpper()) == 0)
                        {
                            r.Visible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                LlenarTabla();
            }
        }
    }
}
