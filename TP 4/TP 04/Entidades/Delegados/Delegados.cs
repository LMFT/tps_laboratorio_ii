using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoNotificar(string mensaje);
    public delegate T DelegadoBuscar<T>(int valor) where T : class;
}
