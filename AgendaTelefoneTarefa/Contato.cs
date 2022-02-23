using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefoneTarefa
{
    internal class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public ListaTelefones Telefones { get; set;}
        public Contato Proximo { get; set; }

        public Contato(string nome, string email, ListaTelefones telefones)
        {
            Nome = nome;
            Email = email;
            Telefones = telefones;
            Proximo = null;
        }
        public override string ToString()
        {
            return "=======================\nNome: " + Nome + "\nEmail: " + Email + "\nTelefones: ";
        }
    }
}
