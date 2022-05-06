using n2.Veículos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class Caminhao : Veiculo, IVeiculosComParabrisa, IVeiculosPagamPedagio
    {
        
        private double pesocarregado;
        private int quantidadedeeixos;
        private double capacidadepeso;

        public double Pesocarregado
        {
            get { return pesocarregado; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Digite uma quantidade correta de peso.");
                }
                else
                    pesocarregado = value;
            }
        }

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


        public double Capacidadepeso
        {
            get { return capacidadepeso; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Digite uma quantidade correta de capacidade de peso.");
                }
                else
                    capacidadepeso = value;
            }
        }
        public void Carregarpeso(double pesoadicional)
        {
            pesocarregado += pesoadicional;
            DispararEvento($"Veículo {Identificacao} carregado com {pesoadicional} kg");
        }
        public void Descarregar()
        {
            pesocarregado = 0;
            DispararEvento($"Veículo {Identificacao} descarregado");
        }

       
        public override void Desacelerar()
        {
            if (Velocidadeatual == 0)
            {
                throw new Exception("Veículo já esta parado");
            }
            velocidadeatual--;
            DispararEvento($"Veículo {Identificacao} desacelerou, velocidade {Velocidadeatual} Km/h");

        }
        public override void Acelerar()
        {
            if (pesocarregado >= capacidadepeso)
            {
                throw new CapacidadeMaximaAtingidaException();
            }
            else
            {
                velocidadeatual++;
                DispararEvento($"Veículo {Identificacao} acelerou, velocidade {Velocidadeatual} Km/h");
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
            return base.ToString() + "Classe: Caminhao" + Environment.NewLine +
                (limpador ? "Limpador ligado" : "Limpador desligado") + Environment.NewLine +
                "Peso carregado: " + pesocarregado + Environment.NewLine +
                "Capacidade máxima em kg: " + capacidadepeso + Environment.NewLine +
                "Quantidade de eixos: " + Quantidadedeeixos + Environment.NewLine;
            
        }

        public double PagarPedagio()
        {
            DispararEvento($"Veículo {Identificacao} pagou pedágio");
            return 8.5 * Quantidadedeeixos;

        }
        
        
    }
}

