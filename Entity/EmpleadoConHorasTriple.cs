using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmpleadoConHorasTriple : Empleado
    {
        int HorasExtra;
        public int CalcularHorasExtra()
        {
            if (HorasTrabajadas > 80)
            {
                HorasExtra = HorasTrabajadas - 40;
            }
            return HorasExtra;
        }

        public override double CalcularSalario()
        {
            Salario = HorasTrabajadas * ValorHora + (CalcularHorasExtra() * (ValorHora + 5000));
            return Salario;
        }
    }
}
