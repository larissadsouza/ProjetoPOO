using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2.Veículos
{
    static class Pedagio
    {
        static double valorTotalRecebido;

        public static double ValorTotalRecebido { get => valorTotalRecebido; set => valorTotalRecebido = value; }

        public static void Receber(Veiculo v)
        {
            double valor;
            if (v is IVeiculosPagamPedagio)
            {
                valor = (v as IVeiculosPagamPedagio).PagarPedagio();
                ValorTotalRecebido += valor;
                
            }
        }
    }
}
