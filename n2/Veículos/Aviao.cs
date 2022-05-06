using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class Aviao : Veiculo, IAviões, IVeiculosComParabrisa
    {
        public bool limpador = false;

        public void Pousar()
        {
            DispararEvento($"Veículo {Identificacao} pousou");
        }
        public void Arremeter()
        {
            DispararEvento($"Veículo {Identificacao} arremeteu");
        }

        public void Decolar()
        {
            DispararEvento($"Veículo {Identificacao} decolou");
        }

        public bool LigaDesligaLimpador()
        {
            if (limpador == false)
            {
                limpador = true;
                DispararEvento($"Veículo {Identificacao} teve seu limpador ligado");
            }
            else
            {
                limpador = false;
                DispararEvento($"Veículo {Identificacao} teve seu limpador desligado");
            }
            return limpador;
        }

        public override string ToString()
        {
            return base.ToString() + "Classe: Aviao" + Environment.NewLine 
            + (limpador ? "Limpador ligado" : "Limpador desligado") + Environment.NewLine;

        }
    }
}
