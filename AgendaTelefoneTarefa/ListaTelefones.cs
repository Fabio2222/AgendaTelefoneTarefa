using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefoneTarefa
{
    internal class ListaTelefones
    {
        public Telefone Head {get; set;}
        public Telefone Tail { get; set; }

        public ListaTelefones()
        {
            Head = Tail = null;
        }
        public void Push(Telefone aux)
        {
            if (Vazio())
            {
                Head = Tail = aux;
            }
            else
            {
                Tail.Proximo = aux;
                Tail = aux;
            }
        }
        public bool Vazio()
        {
            if ((Head == null) && (Tail == null))
                return true;
            return false;
        }   
    }
}
