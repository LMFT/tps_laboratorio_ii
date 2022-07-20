using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IObtener <T> where T : new()
    {
        public T Obtener();
    }
}
