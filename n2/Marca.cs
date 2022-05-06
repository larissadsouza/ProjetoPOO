using System;

namespace n2
{
    public class Marca
    {
        private int codigo;
        private string descricao;

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
                    throw new Exception("Digite uma descrição válida");
                }
                else
                    descricao = value;
            }
        }
    }
}
