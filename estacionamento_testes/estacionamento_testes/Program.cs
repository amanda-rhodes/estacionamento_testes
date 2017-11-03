using System;

namespace estacionamento_testes
{
    class Program
    {
        static void Main(string[] args)
        {
            Estacionamento meuEstacionamento = new Estacionamento(3);

            Console.WriteLine(meuEstacionamento.novoVeiculo("abc1", 10, 1));
            Console.WriteLine(meuEstacionamento.novoVeiculo("abc2", 10, 2));
            Console.WriteLine(meuEstacionamento.novoVeiculo("abc3", 10, 3));
            Console.WriteLine(meuEstacionamento.novoVeiculo("abc4", 10, 4));

            Console.WriteLine("----------");
            meuEstacionamento.listarVeiculos();

            Console.WriteLine(meuEstacionamento.saidaVeiculo("abc2"));

            meuEstacionamento.listarVeiculos();

            Console.WriteLine(meuEstacionamento.novoVeiculo("abc4", 10, 4));

            meuEstacionamento.listarVeiculos();

            Console.WriteLine(meuEstacionamento.saidaVeiculo("abc5"));

            meuEstacionamento.listarVeiculos();

            Console.ReadKey();
        }
    }
}
