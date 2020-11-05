using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmpleadoSinHorasExtra : Empleado
    {
        public override double CalcularSalario()
        {
            Salario = HorasTrabajadas * ValorHora;
            return Salario;
        }
    }
}
