using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class CapacidadeMaximaAtingidaException : Exception
    {
        public CapacidadeMaximaAtingidaException() 
            : base ("Capacidade máxima atingida, veículo não pode acelerar")
        {

        }
    }
}
