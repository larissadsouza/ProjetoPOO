using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace n2.Veículos
{
    public class DispararEventArgs : EventArgs
    {
        private string fraseEvento;

        public string FraseEvento { get => fraseEvento; set => fraseEvento = value; }

        public DispararEventArgs(string frase)
        {
            FraseEvento = frase;
        }
    }
}
