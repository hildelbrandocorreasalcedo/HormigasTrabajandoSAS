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
using System.IO;

namespace GUINominas
{
    public partial class FrmEmpleados : Form, IReceptor
    {
        HormigaService ServicioEmpleado = new HormigaService();

        public FrmEmpleados()
        {
            InitializeComponent();
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try { 
                Empleado empleadoCreado = MapearEmpleado();
                var Mensaje = ServicioEmpleado.Guardar(empleadoCreado);
                MessageBox.Show(Mensaje, "Confirmacion De Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (Exception){

                    MessageBox.Show("Error!! Ingrese TODA La informacion Debidamente", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             Limpiar();
        }

        public Empleado MapearEmpleado()
        {
            Empleado empleadoCreado;
            EmpleadoDTO empleadoDTO = new EmpleadoDTO();

            empleadoDTO.Identificacion = Convert.ToInt32(TxtIdentificacion.Text);
            empleadoDTO.Nombre = TxtNombre.Text;
            empleadoDTO.HorasTrabajadas = Convert.ToInt32(TxtHorasTrabajadas.Text);
            empleadoDTO.ValorHora = Convert.ToInt32(TxtSueldoPorHora.Text);

            empleadoCreado = ServicioEmpleado.CrearEmpleado(empleadoDTO);

            return empleadoCreado;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            var identificacion = TxtIdentificacion.Text;
            if (identificacion!="")
            {
                Empleado empleadoBuscado = ServicioEmpleado.Buscar(Convert.ToInt32(identificacion));
                if (empleadoBuscado!=null)
                {
                    MapearTexto(empleadoBuscado);
                }
                else
                {
                    MessageBox.Show("No Existe El Empleado", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }else
            {
                MessageBox.Show("Digite Una Identificacion A Bsucar", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void MapearTexto(Empleado empleadoBuscado)
        {
            double salario;
            TxtIdentificacion.Text = Convert.ToString(empleadoBuscado.Identificacion);
            TxtNombre.Text = empleadoBuscado.Nombre;
            TxtHorasTrabajadas.Text = empleadoBuscado.HorasTrabajadas.ToString();
            TxtSueldoPorHora.Text = empleadoBuscado.ValorHora.ToString();
            salario = empleadoBuscado.CalcularSalario();
            TxtSueldo.Text = Convert.ToString(salario);
            TxtTipo.Text = empleadoBuscado.Tipo;
        }

        public void Limpiar() { 
            TxtIdentificacion.Text = "";
            TxtNombre.Text = "";
            TxtHorasTrabajadas.Text = "";
            TxtSueldoPorHora.Text = "";
            TxtSueldo.Text = "";
            TxtTipo.Text = "";
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            var identificacion = TxtIdentificacion.Text;
            if (identificacion != "")
            {
                Empleado empleadoBuscado = ServicioEmpleado.Buscar(Convert.ToInt32(identificacion));
                if (empleadoBuscado != null)
                {
                    var Mensaje = ServicioEmpleado.Eliminar(ServicioEmpleado.Buscar(Convert.ToInt32(TxtIdentificacion.Text)));
                    MessageBox.Show(Mensaje, "Confirmacion De Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Existe Esa Persona", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Digite Una Identificacion A Buscar", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Limpiar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            var identificacion = TxtIdentificacion.Text;
            if (identificacion != "")
            {
                Empleado empleadoBuscado = ServicioEmpleado.Buscar(Convert.ToInt32(identificacion));
                if (empleadoBuscado != null)
                {
                    ServicioEmpleado.Eliminar(ServicioEmpleado.Buscar(Convert.ToInt32(TxtIdentificacion.Text)));

                    try
                    {
                        Empleado empleadoCreado = MapearEmpleado();
                        ServicioEmpleado.Guardar(empleadoCreado);
                        MessageBox.Show("Se Actualizaron los Datos", "Confirmacion De Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error!! Ingrese TODA La informacion Debidamente", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No Existe Esa Persona Registrada Con esta identificacion", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Dijite Una Identificacion A Modificar", "Confirmacion De Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Limpiar();
        }

        public void Recibir(Empleado empleado)
        {
            //TxtIdentificacion.Text = Convert.ToString(empleado.Identificacion);
            if (empleado != null)
            {
                MapearTexto(empleado);
            }
        }

        private void BtnAbrirConsulta_Click(object sender, EventArgs e)
        {
            FrmConsulta consulta = new FrmConsulta(this);
            consulta.Show();
        }
    }
}
