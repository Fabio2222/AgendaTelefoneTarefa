using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefoneTarefa
{
    internal class ListaContatos
    {
        public Contato Head { get; set; }
        public Contato Tail { get; set; }

        public ListaContatos()
        {
            Head = Tail = null;
        }
        public void Push(Contato aux)
        {
            if (Vazio())
            {
                Head = Tail = aux;
            }
            else
            {
                if (String.Compare(aux.Nome, Tail.Nome) >= 0) // entra no lugar do último
                {
                    Tail.Proximo = aux;
                    Tail = aux;
                }
                else if (String.Compare(aux.Nome, Head.Nome) <= 0) //entra no lugar do primeiro
                {
                    aux.Proximo = Head;
                    Head = aux;
                }
                else                               // entra no meio
                {
                    Contato aux1 = Head;     // cria dois aux (aux 1 - proximo, aux 2 anterior)
                    Contato aux2 = Head;
                    do
                    {
                        if (String.Compare(aux.Nome, aux1.Nome) > 0) // olhar slide lista numero 23 com 2 aux
                        {
                            aux2 = aux1;
                            aux1 = aux1.Proximo;
                        }
                        else
                        {
                            aux2.Proximo = aux;
                            aux.Proximo = aux1;
                        }
                    } while (aux.Proximo == null);
                }
            }
        }

        public bool Vazio()
        {
            if ((Head == null) && (Tail == null))
                return true;
            return false;
        }

        public void Busca(string busca)
        {
            if (Vazio())
            {
                Console.WriteLine(">>>>>>NENHUM CONTATO ENCONTRADO<<<<<<");
            }
            else
            {
                Console.Clear();
                Console.WriteLine(">>>>>>BUSCA POR CONTATO<<<<<<");
                Contato aux = Head;
                bool achei = false;
                do
                {
                    if (string.Equals(aux.Nome.ToLower(), busca)) // faz a busca. Nome identico - equals
                    {
                        Console.WriteLine(aux.ToString());       // mostra as informacoes do contato
                        Telefone telefones = aux.Telefones.Head;   // aqui pega 1º telefone
                        do
                        {
                            Console.WriteLine(telefones.ToString());  // mostra todos os telefones do contato
                            telefones = telefones.Proximo;
                        } while (telefones != null);
                        achei = true;
                    }
                    else if (aux.Nome.ToLower().Contains(busca))  // busca nomes iguais - contains - se a busca esta contido no nome do contato
                    {
                        Console.WriteLine(aux.ToString());
                        Telefone telefones = aux.Telefones.Head;
                        do
                        {
                            Console.WriteLine(telefones.ToString());
                            telefones = telefones.Proximo;
                        } while (telefones != null);
                        achei = true;
                    }
                    aux = aux.Proximo;
                } while (aux != null);
                if (!achei)
                {
                    Console.WriteLine("Nenhum contato com este nome encontrado");
                }
                Console.ReadKey();
            }
        }


        public void Pop(string apagar)  //pop = apaga contato
        {
            if (Vazio())
            {
                Console.WriteLine("======NENHUM CONTATO ENCONTRADO======");
            }
            else
            {
                bool achei = false;
                Contato aux1 = Head;
                Contato aux2 = Head;
                do                     // laço repeticao
                {
                    if (string.Equals(Head.Nome.ToLower(), apagar))  // apaga nome na cabeça , o primeiro nome
                    {
                        Head = Head.Proximo;
                        achei = true;
                        break;  // sai apos apagar um contato
                    }
                    else if (!string.Equals(aux1.Nome.ToLower(), apagar)) // busca ate encontrar o contato desejado
                    {
                        aux2 = aux1; // os 2 apontam para cabeça
                        aux1 = aux1.Proximo;  //percorre sentido final da fila - Obj1=>=>Obj2=>=>Obj3=>=>Obj4
                    }
                    else if (string.Equals(Tail.Nome.ToLower(), apagar)) // apaga se for o ultimo
                    {
                        aux2.Proximo = aux1.Proximo; //aux 1 e aux 2 apontam para cauda Obj4
                        Tail = aux2;  //cabeca aponta aux2 que é Obj3
                        achei = true;
                        break;
                    }
                    else if (string.Equals(aux1.Nome.ToLower(), apagar)) // apaga o do meio
                    {
                        aux2.Proximo = aux1.Proximo;
                        achei = true;
                        break;
                    }
                } while (aux1 != null);
                if (!achei)
                {
                    Console.WriteLine("Nenhum contato com este nome encontrado");
                    Console.ReadKey();
                }
                else
                {
                    if (Head == null)
                        Head = Tail = null;
                }
            }

        }

        public void Alterar(string altera)  // alterar contato
        {
            if (Vazio())
            {
                Console.WriteLine("======NENHUM CONTATO ENCONTRADO======");
            }
            else
            {
                Contato aux = Head;
                int opc;
                do
                {
                    if (string.Equals(aux.Nome.ToLower(), altera))
                    {
                        Console.WriteLine(aux.ToString());       //mostra todas as informações do contato
                        Telefone telefone = aux.Telefones.Head;
                        do
                        {
                            Console.WriteLine(telefone.ToString());
                            telefone = telefone.Proximo;
                        } while (telefone != null);
                        Console.Write("Que informação deseja alterar: ");
                        Console.WriteLine("\n1-Nome");
                        Console.WriteLine("2-E-mail");
                        Console.WriteLine("3-Telefone");
                        Console.Write("Opção: ");
                        opc = int.Parse(Console.ReadLine());
                        switch (opc)
                        {
                            case 1:
                                Console.Write("Digite o novo nome: ");
                                // Push para criar um novo contato, um novo nome e mesmo email e telefones
                                Push(new Contato(Console.ReadLine(), aux.Email, aux.Telefones));
                                Pop(aux.Nome.ToLower());  // apaga contato a ser alterado
                                break;
                            case 2:
                                Console.Write("Digite o novo E-mail: ");
                                aux.Email = Console.ReadLine(); // troca por um email novo
                                break;
                            case 3:
                                telefone = aux.Telefones.Head;  // aux aponta 1 telefone (cabeca)
                                int tipo;
                                string tipoescolhido;
                                do
                                {
                                    Console.WriteLine(telefone.ToString());  // busca todos os telefones
                                    telefone = telefone.Proximo;
                                } while (telefone != null);
                                Console.WriteLine("Qual telefone deseja alterar: ");
                                Console.WriteLine("1-Celular");
                                Console.WriteLine("2-Residencial");
                                Console.WriteLine("3-Trabalho");
                                Console.WriteLine("4-Recado");
                                tipo = int.Parse(Console.ReadLine());
                                switch (tipo)
                                {
                                    case 1:
                                        tipoescolhido = "Celular";
                                        break;
                                    case 2:
                                        tipoescolhido = "Residencial";
                                        break;
                                    case 3:
                                        tipoescolhido = "Trabalho";
                                        break;
                                    case 4:
                                        tipoescolhido = "Recado";
                                        break;
                                    default:
                                        tipoescolhido = "Invalido";
                                        break;
                                }
                                telefone = aux.Telefones.Head;
                                do
                                {
                                    if (string.Equals(telefone.Tipo, tipoescolhido))
                                    {
                                        Console.WriteLine("Digite o novo DDD {0}: ", tipoescolhido);
                                        telefone.DDD = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Digite o novo numero {0}: ", tipoescolhido);
                                        telefone.Numero = Console.ReadLine();
                                    }
                                    telefone = telefone.Proximo;
                                } while (telefone != null);
                                break;
                        }
                        break;
                    }
                    aux = aux.Proximo;
                } while (aux != null);
            }
        }

        public void Print()
        {
            if (Vazio())
            {
                Console.WriteLine("======AGENDA VAZIA======");
            }
            else
            {
                Contato aux = Head; //inicia pela cabeca
                do
                {
                    Console.WriteLine(aux.ToString()); // mostra as informacoes contato - nome, email apenas
                    Telefone telefone = aux.Telefones.Head;  // busca primeiro telefone do contato
                    do
                    {
                        Console.WriteLine(telefone.ToString());  // mostra um telefone do contato
                        telefone = telefone.Proximo;              // faz ir para o proximo telefone, ate mostrar todos
                    } while (telefone != null);   // final 
                    aux = aux.Proximo;  // faz ir para proximo contato
                    Console.ReadKey();
                } while (aux != null);
                Console.WriteLine("======FIM DA IMPRESSÃO======");
            }
        }
    }
}
