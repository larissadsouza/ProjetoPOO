using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class NaviodeGuerra : Veiculo, INavios, IGuerra
    {
        public void Atacar()
        {
            DispararEvento($"Veículo {Identificacao} atacou");
        }

        public void Atracar()
        {
            DispararEvento($"Veículo {Identificacao} atracou");
        }
        public override string ToString()
        {
            return base.ToString() + "Classe: Navio de Guerra" + Environment.NewLine;
        }
    }
}
