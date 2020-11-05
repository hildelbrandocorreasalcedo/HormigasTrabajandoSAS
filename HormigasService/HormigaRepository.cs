using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;


namespace DAL
{
    public class HormigaRepository
    {
        List<Empleado> empleados =  new List<Empleado>();
        

        public void Guardar(Empleado empleado)
        {
            FileStream archivo = new FileStream("empleados.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(archivo);
            writer.WriteLine(empleado.Identificacion + ";" + empleado.Tipo + ";" + empleado.Nombre + ";" + empleado.HorasTrabajadas + ";" + empleado.ValorHora + ";" + empleado.CalcularSalario());
            writer.Close();
            archivo.Close();
        }

        public List<Empleado> Consultar()
        {
            empleados.Clear();
            FileStream archivo = new FileStream("empleados.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(archivo);
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {
                Empleado empleado;
                empleado = Map(linea);
                empleados.Add(empleado);
            }
            reader.Close();
            archivo.Close();
            return empleados;
        }


        public void Eliminar(Empleado empleado)
        {
            FileStream archivo = new FileStream("empleados.txt", FileMode.Create);
            archivo.Close();

            foreach (var item in empleados)
            {
                if (item.Identificacion != empleado.Identificacion)
                {
                    Guardar(item);
                }
            }
        }


        public Empleado Buscar(int identificacion)
        {

            empleados = Consultar();

            /*foreach (var item in empleados)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;*/

            return empleados.Where(e => e.Identificacion == identificacion).FirstOrDefault();
        }

        public void Modificar(Empleado empleado, int id)
        {
            empleado.Identificacion = id;
        }

        public Empleado Map(string linea)
        {
            char delimiter = ';';
            string[] datosEmpleado = linea.Split(delimiter);
            Empleado empleado;

            if (datosEmpleado[1]=="EMP.SINHORAS")
            {
                empleado = new EmpleadoSinHorasExtra();
            }
            else
            {
                if(datosEmpleado[1] == "EMP.HORASDOBLE")
                {
                    empleado = new EmpleadoConHorasDoble();
                }
                else
                {
                    empleado = new EmpleadoConHorasTriple();
                }
            }

            empleado.Identificacion = int.Parse(datosEmpleado[0]);
            empleado.Tipo = datosEmpleado[1];
            empleado.Nombre = datosEmpleado[2];
            empleado.HorasTrabajadas = int.Parse(datosEmpleado[3]);
            empleado.ValorHora = double.Parse(datosEmpleado[4]);
            empleado.Salario = double.Parse(datosEmpleado[5]);
            return empleado;
        }
    }
}

