using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmpleadoConHorasDoble : Empleado
    {

        int HorasExtra;
        public int CalcularHorasExtra()
        {
            if (HorasTrabajadas > 40 && HorasTrabajadas<=80)
            {
                HorasExtra = HorasTrabajadas - 40;
            }
            return HorasExtra;
        }

        public override double CalcularSalario()
        {
            Salario = HorasTrabajadas * ValorHora + (CalcularHorasExtra() * (ValorHora + 3000));
            return Salario;
        }
    }
}
