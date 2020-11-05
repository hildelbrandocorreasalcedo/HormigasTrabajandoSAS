using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace GUINominas
{
    public interface IReceptor
    {
        void Recibir(Empleado empleado);
        
    }
}
