using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class Navio : Veiculo, INavios
    {
        public void Atracar()
        {
            DispararEvento($"Veículo {Identificacao} atracou");
        }

        public override string ToString()
        {
            return base.ToString() + "Classe: Navio" + Environment.NewLine;
        }
    }
}
