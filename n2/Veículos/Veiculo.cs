using n2.Veículos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    public class Veiculo
    {
        private string identificacao;
        private int capacidadepassageiros;
        public Modelo modeloveiculo;
        public event EventHandler<DispararEventArgs> EscreverNaTela;

        public string Identificacao
        {
            get { return identificacao; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                    throw new Exception("Preencha a identificação!");

                else
                    identificacao = value;

            }
        }


        public Modelo Modeloveiculo
        {
            get { return modeloveiculo; }
            set { modeloveiculo = value; }
        }

        public int velocidadeatual = 0;

        public int Velocidadeatual
        {
            get { return velocidadeatual; }
            set { velocidadeatual = value; }
        }

        virtual public void Acelerar()
        {
            velocidadeatual++;
            DispararEvento($"Veículo {Identificacao} acelerou, velocidade {Velocidadeatual} Km/h");
        }
        virtual public void Desacelerar()
        {
            if (Velocidadeatual == 0)
            {
                throw new Exception("Veículo já esta parado");
            }
            velocidadeatual--;
            DispararEvento($"Veículo {Identificacao} desacelerou, velocidade {Velocidadeatual} Km/h");

        }
        public int Capacidadepassageiros
        {
            get { return capacidadepassageiros; }
            set
            {
                if (value <= 0)
          
                {
                    throw new Exception("Digite uma quantidade correta de passageiros.");
                }
                else
                    capacidadepassageiros = value;
            }
        }

        public override string ToString()
        {
            return
                "Identificação: " + identificacao + Environment.NewLine +
                "Modelo: " + modeloveiculo.Codigo + " - " + modeloveiculo.Descricao + Environment.NewLine +
                "Marca: " + modeloveiculo.Marca.Codigo + " - " + modeloveiculo.Marca.Descricao + Environment.NewLine +
                "Capacidade de passageiros: " + capacidadepassageiros + Environment.NewLine +
                "Velocidade atual em KM: " + Velocidadeatual + Environment.NewLine;

        }
       

        protected void DispararEvento (string frase)
        {
            if (EscreverNaTela != null)
                EscreverNaTela(this, new DispararEventArgs(frase));
        }
    }


}
