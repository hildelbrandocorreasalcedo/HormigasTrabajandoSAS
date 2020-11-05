using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class HormigaService
    {
        HormigaRepository repositorio = new HormigaRepository();

        public string Guardar(Empleado empleado)
        {
            if (repositorio.Buscar(empleado.Identificacion) == null)
            {
                repositorio.Guardar(empleado);
                return $"El Empleado Ha sido Guardado con Exito";
            }
            else
            {
                return $"El Empleado Ya se encuentra Registrado en el Sistema";
            }
        }

        public Empleado Buscar(int buscarCodigo)
        {
            return repositorio.Buscar(buscarCodigo);
        }

        public List<Empleado> Consultar()
        {
            return repositorio.Consultar();
        }

        public string Eliminar(Empleado empleado)
        {
            if (repositorio.Buscar(empleado.Identificacion) == null)
            {

                return $"El Empleado No Se Encuentra Registrado en el Sistema";
            }
            else
            {              
                repositorio.Eliminar(empleado);
                return $"El Empleado Ha sido Eliminado con Exito";        
            }

        }

        public string Modificar(Empleado empleado, int id)
        {
            repositorio.Modificar(empleado, id);
            return "El empleado Ha Sido Modificado Con Exito";
        }

        public Empleado CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            if (empleadoDTO.HorasTrabajadas > 0 && empleadoDTO.HorasTrabajadas <= 40)
            {
                Empleado empleado = new EmpleadoSinHorasExtra();
                empleado.Identificacion = empleadoDTO.Identificacion;
                empleado.Tipo = "EMP.SINHORAS";
                empleado.Nombre = empleadoDTO.Nombre;
                empleado.ValorHora = empleadoDTO.ValorHora;
                empleado.HorasTrabajadas = empleadoDTO.HorasTrabajadas;
                empleado.Salario = empleadoDTO.Salario;
                return empleado;
            }
            else
            {
                if (empleadoDTO.HorasTrabajadas >40 && empleadoDTO.HorasTrabajadas < 80)
                {
                    Empleado empleado = new EmpleadoConHorasDoble();
                    empleado.Identificacion = empleadoDTO.Identificacion;
                    empleado.Tipo = "EMP.HORASDOBLE";
                    empleado.Nombre = empleadoDTO.Nombre;
                    empleado.ValorHora = empleadoDTO.ValorHora;
                    empleado.HorasTrabajadas = empleadoDTO.HorasTrabajadas;
                    empleado.Salario = empleadoDTO.Salario;
                    return empleado;
                }
                else
                {
                    if (empleadoDTO.HorasTrabajadas >= 80)
                    {
                        Empleado empleado = new EmpleadoConHorasTriple();
                        empleado.Identificacion = empleadoDTO.Identificacion;
                        empleado.Tipo = "EMP.HORASTRIPLE";
                        empleado.Nombre = empleadoDTO.Nombre;
                        empleado.ValorHora = empleadoDTO.ValorHora;
                        empleado.HorasTrabajadas = empleadoDTO.HorasTrabajadas;
                        empleado.Salario = empleadoDTO.Salario;
                        return empleado;
                    }
                }
            }           
            return null;
        }
    }

   

    public class EmpleadoDTO
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public int HorasTrabajadas { get; set; }
        public double ValorHora { get; set; }
        public double Salario { get; set; }

        public EmpleadoDTO()
        {
        }

        public EmpleadoDTO(int identificacion, string nombre, int horasTrabajadas, double valorHora, double salario)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            HorasTrabajadas = horasTrabajadas;
            ValorHora = valorHora;
            Salario = salario;
        }

    }
}
