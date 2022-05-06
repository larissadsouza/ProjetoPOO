using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    public class Modelo
    {
        private int codigo;
        private string descricao;
        private Marca marca;

        public int Codigo
        {
            get { return codigo; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Digite um codigo valido");
                }
                else
                    codigo = value;
            }
        }

        public string Descricao
        {
            get { return descricao; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new Exception("Preencha a descrição!");
                }
                else
                    descricao = value;
            }
        }

        internal Marca Marca
        {
            get => marca;
            set
            {
                if (value == null)
                    throw new Exception("Selecione a marca");

                marca = value;
            }
        }
    }
}

