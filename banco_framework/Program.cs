using Application;
using Domain.Model;
using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");

        var cliente = Identificacao();
        var calculo = new Calculo();
        int option = 0;

        do
        {
            Console.Clear();
            Console.Write($"Como posso ajudar {cliente.Nome}?\n" +
            "1 - Depósito\n" +
            "2 - Saque\n" +
            "3 - Sair");

            Console.WriteLine("");

            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção:");

            option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Clear();

                Console.WriteLine("Digite o valor:");

                float deposito = float.Parse(Console.ReadLine());

                if (deposito < 0)
                {
                    Console.WriteLine("Valor inválido.");

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Seu atual é: {calculo.Soma(cliente.Saldo, deposito).ToString("C")}");

                    Console.ReadKey();
                }
            }
            else if (option == 2)
            {
                Console.Clear();

                Console.WriteLine("Digite o valor:");

                float saque = float.Parse(Console.ReadLine());

                if (saque > cliente.Saldo)
                {
                    Console.WriteLine("Saldo insuficiente.");

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Seu atual é: {calculo.Subtracao(cliente.Saldo, saque).ToString("C")}");

                    Console.ReadKey();
                }
            }
        } while (option != 3);
    }

    static Cliente Identificacao()
    {
        var cliente = new Cliente();

        Console.WriteLine("Seu número de identificação:");
        cliente.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        cliente.Cpf = Console.ReadLine();

        Console.WriteLine("Seu saldo:");
        cliente.Saldo = float.Parse(Console.ReadLine());

        Console.Clear();

        return cliente;
    }
}