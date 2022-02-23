using System;

namespace AgendaTelefoneTarefa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //criando a minha lista de contatos
            ListaContatos minhalista = new ListaContatos();
            int opc;  // criando a variavel opcao

            do
            {
                Console.Clear();
                Console.WriteLine("======MENU PRINCIPAL======");
                Console.WriteLine("1-Cadastrar contato");
                Console.WriteLine("2-Localizar contato");
                Console.WriteLine("3-Remover contato");
                Console.WriteLine("4-Editar contato");
                Console.WriteLine("5-Imprimir contatos");
                Console.WriteLine("0-Sair");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Informe o nome do contato: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Informe o e-mail do contato: ");
                        string email = Console.ReadLine();
                        ListaTelefones listatel = new ListaTelefones();
                        int newcontato;
                        do
                        {
                            Console.WriteLine("Informe o tipo de telefone: ");
                            Console.WriteLine("1 - CELULAR"); 
                            Console.WriteLine("2 - RESIDENCIAL");
                            Console.WriteLine("3 - TRABALHO"); 
                            Console.WriteLine("4 - RECADO");
                            int tipo = int.Parse(Console.ReadLine());
                            string tipoescolhido;

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
                            Console.Write("Digite o DDD da sua cidade: ");
                            int ddd = int.Parse(Console.ReadLine());
                            Console.Write("Digite o numero de telefone: ");
                            string numero = Console.ReadLine();
                            listatel.Push(new Telefone(tipoescolhido, ddd, numero)); // criando um telefone na lista de telefone
                            Console.WriteLine("Deseja adicionar um novo numero?(1-para sim | 0 para nao)");
                            newcontato = int.Parse(Console.ReadLine());


                        } while (newcontato != 0);

                        minhalista.Push(new Contato(nome, email, listatel)); // criando uma novo contato com uma lista de telefone
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Informe nome que deseja buscar: ");
                        string busca = Console.ReadLine().ToLower();
                        minhalista.Busca(busca);  //  minhalista nome lista de contatos
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Informe o nome que deseja apagar: ");
                        string apaga = Console.ReadLine().ToLower();
                        minhalista.Pop(apaga);  //  o pop recebe o que for apagar
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Informe o nome que deseja alterar: ");
                        string altera = Console.ReadLine().ToLower();
                        minhalista.Alterar(altera);
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        minhalista.Print();
                        Console.ReadKey();
                        break;
                }
            } while (opc!=0);    
        }
    }
}
