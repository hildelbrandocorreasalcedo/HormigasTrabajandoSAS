using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class Empleado
    {
        public int Identificacion { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public int HorasTrabajadas { get; set; }
        public double ValorHora { get; set; }
        public double Salario { get; set; }

        //public virtual double Salario { get; set; }

        public abstract double CalcularSalario();
    }
}
