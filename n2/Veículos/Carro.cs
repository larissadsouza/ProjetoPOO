using n2.Veículos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class Carro : Veiculo, IVeiculosComParabrisa, IVeiculosPagamPedagio
    {
        private int quantidadeportas;
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

        public int Quantidadeportas
        {
            get { return quantidadeportas; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Digite uma quantidade correta de portas.");
                }
                else
                    quantidadeportas = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + "Classe: Carro" + Environment.NewLine 
                + "Quantidade de portas: " + quantidadeportas + Environment.NewLine +
                (limpador ? "Limpador ligado" : "Limpador desligado") + Environment.NewLine;
        }

        public double PagarPedagio()
        {
            DispararEvento($"Veículo {Identificacao} pagou pedágio");
            return 7;
        }
    }
}
