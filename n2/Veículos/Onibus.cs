using n2.Veículos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{

    class Onibus : Veiculo ,IVeiculosComParabrisa, IVeiculosPagamPedagio
    {
        private int quantidadedeeixos;
        
        public int Quantidadedeeixos
        {
            get { return quantidadedeeixos; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Digite uma quantidade correta de eixos.");
                    
                }
                else
                    quantidadedeeixos = value;
            }
        }

        public bool leito = false;

        public bool Leito
        {
            get { return leito; }
            set
            {
                leito = value;
            }
        }

        

        public bool limpador = false;
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
            return base.ToString() + "Classe: Onibus" + Environment.NewLine 
                + (limpador ? "Limpador ligado" : "Limpador desligado") + Environment.NewLine +
                "Quantidade de eixos: " + quantidadedeeixos + Environment.NewLine +
                "Leito: " + (leito ? "Sim" : "Não") + Environment.NewLine;
        }

        public double PagarPedagio()
        {
            DispararEvento($"Veículo {Identificacao} pagou pedágio");
            return 8.5 * Quantidadedeeixos;
           
            
        }
    }
}

