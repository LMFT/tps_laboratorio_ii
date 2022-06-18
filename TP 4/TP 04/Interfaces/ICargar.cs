using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICargar<T> where T : class
    {
        public T Cargar(object[] valores);
    }
}
