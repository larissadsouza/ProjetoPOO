using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class Trem : Veiculo, IVeiculosComParabrisa
    {
        private int quantidadeDeVagoes;

        public int QuantidadeDeVagoes { get => quantidadeDeVagoes; set => quantidadeDeVagoes = value; }

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
        public bool limpador = false;
        public override string ToString()
        {
            return base.ToString() + "Classe: Trem" + Environment.NewLine +
                "Quantidade de vagões: " +  QuantidadeDeVagoes + Environment.NewLine +
                (limpador ? "Limpador ligado" : "Limpador desligado") + Environment.NewLine; 
        }

    }
}
