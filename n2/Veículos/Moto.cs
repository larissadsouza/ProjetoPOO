using n2.Veículos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class Moto : Veiculo,IVeiculosPagamPedagio
    {
        
        public void Empinar()
        {
           
            DispararEvento($"Veículo {Identificacao} empinou");
            
        }

        public double PagarPedagio()
        {
            DispararEvento($"Veículo {Identificacao} pagou pedágio");
            return 3;
           
        }
        public override string ToString()
        {
            return base.ToString() + "Classe: Moto";
        }
    }
}
