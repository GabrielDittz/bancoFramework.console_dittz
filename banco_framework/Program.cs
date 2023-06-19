using Application;
using Domain.Model;
using System.ComponentModel.Design;
using CpfCnpjLibrary;
using System.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");

        Console.ReadKey();

        var cliente = Identificacao();

        var calculo = new Calculo();
        int opcao = 0;

        while(opcao != 3)
        {
            opcao = Menu(cliente, opcao);

            if(opcao == 1)
            {
                Console.Clear();

                Console.WriteLine("\"Digite o valor para depositar:");
                var valor = float.Parse(Console.ReadLine());

                cliente.Saldo = calculo.Soma(cliente.Saldo, valor);

                Console.WriteLine($"Seu saldo atual é {cliente.Saldo.ToString("C")}");

                Console.ReadLine();
            }else if(opcao == 2)
            {
                Console.Clear();

                Console.WriteLine("Digite o valor para sacar:");
                var valor = float.Parse(Console.ReadLine());

                cliente.Saldo = calculo.Subtracao(cliente.Saldo, valor);

                Console.WriteLine($"Seu saldo atual é {cliente.Saldo.ToString("C")}");

                Console.ReadLine();
            }
        }
    }

    static Cliente Identificacao()
    {
        var cliente = new Cliente();

        var erros = new List<string>
        {
            " "
        };

        while (erros.Count() != 0)
        {
            erros.Clear();

            Console.Clear();

            Console.WriteLine("Seu número de identificação:");
            var id = Console.ReadLine();

            if (!int.TryParse(id, out _))
            {
                erros.Add("Identificador não é válido.");
            }
            else
            {
                cliente.Id = int.Parse(id);
            }

            Console.WriteLine("Seu nome:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Seu CPF:");
            cliente.Cpf = Console.ReadLine();

            if (Cpf.Validar(cliente.Cpf) == false)
            {
                erros.Add("CPF digitado não é válido.");
            }

            Console.WriteLine("Seu saldo:");
            var saldo = Console.ReadLine();

            if (!float.TryParse(saldo, out _))
            {
                erros.Add("Saldo não é válido.");
            }
            else
            {
                cliente.Saldo = float.Parse(saldo);
            }

            if (erros.Count() > 0)
            {
                foreach (var item in erros)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }
        }

        Console.Clear();

        return cliente;
    }

    static int Menu(Cliente cliente, int opcao)
    {
        Console.Clear();

        Console.Write($"Como posso ajudar {cliente.Nome}?\n" +
            "1 - Depósito\n" +
            "2 - Saque\n" +
            "3 - Sair");

        Console.WriteLine("");

        Console.WriteLine("----------");
        Console.WriteLine("Selecione uma opção:");

        opcao = int.Parse(Console.ReadLine());

        return opcao;
    }
}