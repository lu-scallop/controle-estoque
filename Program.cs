using System.ComponentModel.Design;
using System.Security.Principal;
using System.Text.RegularExpressions;
using ClasseRoupa;

//Protótipo de um controle de estoque de uma loja de roupas
namespace ControleEstoque 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;

            int posicao = 0;

            //Vetor para armazenar as roupas
            Roupa[] roupas = new Roupa[50];
            while (displayMenu)
            {

                Console.WriteLine("[1] Novo");
                Console.WriteLine("[2] Listar Produtos");
                Console.WriteLine("[3] Remover Produtos");
                Console.WriteLine("[4] Entrada Estoque");
                Console.WriteLine("[5] Saída Estoque");
                Console.WriteLine("[0] Sair");

                string resposta = Console.ReadLine();

                switch (resposta)
                {
                    case "1":


                        Roupa roupa = new Roupa();

                        Console.Write("Informe o tipo de roupa(ex: Camisa, Calça, Bermuda,...):");
                        roupa.Tipo = Console.ReadLine();

                        Console.Write("\nInforme o gênero:");
                        roupa.Genero = Console.ReadLine();

                        Console.Write("\nInforme a cor:");
                        roupa.Cor = Console.ReadLine();

                        Console.Write("\nInforme a marca:");
                        roupa.Marca = Console.ReadLine();

                        Console.Write("\nInforme o código da roupa:");
                        roupa.Codigo = Console.ReadLine();

                        Console.Write("\nInforme o preço(R$):");
                        roupa.Preco = double.Parse(Console.ReadLine());

                        roupa.Estoque = 0;
                        
                        //guarda a roupa no vetor a cada adição
                        roupas[posicao] = roupa;
                        posicao++;

                        Console.WriteLine("\nPeça de roupa adicionada!");

                    

                        break;

                    case "2":

                        //lista todas as roupas adicionadas com o tipo, código e preço.
                        foreach (Roupa item in roupas)
                        {
                            if (item != null)
                            {
                                Console.WriteLine(item.Tipo + " - " + item.Codigo + " - " + " (R$" + item.Preco + ")" + " - " + item.Estoque + " no estoque.");

                            }
                        }
                        break;

                    case "3":

                        
                        Console.WriteLine("Informe o código para excluir a roupa:");
                        string codigo = Console.ReadLine();

                        int posicaoRemover = -1;
                        for (int pos = 0; pos < posicao; pos++)
                        {
                            if (codigo == roupas[pos].Codigo)
                            {
                                posicaoRemover = pos;
                                break;
                            }

                        }

                        //exclui a roupa de acordo com sua posição
                        if (posicaoRemover != -1)
                        {
                            for (int pos = posicaoRemover + 1; pos < posicao; pos++)
                            {
                                roupas[pos - 1] = roupas[pos];
                            }
                            roupas[posicao - 1] = null;
                            posicao--;
                            Console.WriteLine("Roupa removida com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Roupa não encontrada.");
                        }
                        break;


                    case "4":

                        //adiciona roupas ao estoque
                        Console.WriteLine("Informe o código da roupa:");
                        string codigoEntrada = Console.ReadLine();

                        Console.Write("\nDigite quantos produtos serão adicionados:");
                        int roupaEntrada = int.Parse(Console.ReadLine());

                        bool entradaEncontrada = false;

                        for (int pos = 0; pos < roupas.Length; pos++)
                        {
                            if (codigoEntrada == roupas[pos].Codigo)
                            {
                                roupas[pos].Estoque += roupaEntrada;
                                Console.WriteLine("Quantidade adicionada ao estoque.");
                                entradaEncontrada = true;
                                break;
                            }

                        }
                        if (!entradaEncontrada)
                        {
                            Console.WriteLine("Roupa não encontrada.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Informe o código da roupa:");
                        string codigoSaida = Console.ReadLine();

                        Console.Write("\nDigite quantos produtos serão retirados:");
                        int roupaSaida = int.Parse(Console.ReadLine());

                        bool saidaEncontrada = false;

                        for (int pos = 0; pos < posicao; pos++)
                        {
                            if (codigoSaida == roupas[pos].Codigo)
                            {
                                roupas[pos].Estoque -= roupaSaida;
                                Console.WriteLine("Quantidade retirada do estoque.");

                            }

                        }
                        if (!saidaEncontrada)
                        {
                            Console.WriteLine("Roupa não encontrada.");
                        }
                        break;


                    case "0":

                        displayMenu = false;
                        break;
                }
            }



        }




    }

}