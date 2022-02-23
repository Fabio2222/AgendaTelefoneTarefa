using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefoneTarefa
{
    internal class Telefone
    {
        public string Tipo { get; set; }
        public int DDD { get; set; }
        public string Numero { get; set; }
        public Telefone Proximo { get; set; }

        public Telefone(string tipo, int ddd, string numero)
        {
            Tipo = tipo;
            DDD = ddd;
            Numero = numero;
            Proximo = null;
        }

        public override string ToString()
        {
            return Tipo+":("+DDD+")"+Numero;
        }
    }
}
