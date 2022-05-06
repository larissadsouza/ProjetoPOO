using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class AviaodeGuerra : Veiculo, IAviões, IGuerra
    {
        public void Arremeter()
        {
            DispararEvento($"Veículo {Identificacao} arremeteu");
        }

        public void Atacar()
        {
            DispararEvento($"Veículo {Identificacao} atacou");
        }

        public void Decolar()
        {
            DispararEvento($"Veículo {Identificacao} decolou");
        }

        public void Pousar()
        {
            DispararEvento($"Veículo {Identificacao} pousou");
        }

        public void Ejetar()
        {
            DispararEvento($"Veículo {Identificacao} ejetou");
        }

        public override string ToString()
        {
            return base.ToString() + "Classe: Aviao de Guerra" + Environment.NewLine;
        }
    }
}
