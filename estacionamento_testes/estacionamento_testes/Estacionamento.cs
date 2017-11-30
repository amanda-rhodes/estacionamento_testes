using System;
using System.Collections.Generic;

namespace estacionamento_testes
{
    public class Estacionamento
    {
        private const double valorSegundos = 3.50;

        public int NumVagas { get; set; }

        public List<Veiculo> Estacionados { get; set; }

        public static double ValorHora => valorSegundos;

        public Estacionamento(int numVagas)
        {
            if (numVagas < 1)
                throw new Exception("o valor do parâmetro não pode ser menor do que 1 (um)");
            else
            {
                NumVagas = numVagas;
                Estacionados = new List<Veiculo>();
            }
        }

        public bool cheio()
        {
            return Estacionados.Count == NumVagas;
        }

        public bool novoVeiculo(string placa, int hora, int minutos)
        {
            try
            {
                if (string.IsNullOrEmpty(placa))
                    throw new ArgumentNullException(placa, "o valor do parâmetro não pode ser null");
                else if (hora < 0 || hora > 23)
                    throw new Exception("o valor do parâmetro não pode ser negativo ou maior que 23");
                else if (minutos < 0 || minutos > 59)
                    throw new Exception("o valor do parâmetro não pode ser negativo ou maior que 59");
                else if (!placaValida(placa))
                       throw new Exception("a placa precisa ter pelo menos 1 (um) inteiro e 1(uma) letra");
                else
                {
                    Veiculo novo = new Veiculo(placa) {HoraEntrada = new DateTime(1, 1, 1, hora, minutos, 0)};

                    if (cheio() != false) return false;
                    novo.HoraEntrada = DateTime.Now;
                    Estacionados.Add(novo);
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public double calcularValor(Veiculo veic)
        {
            TimeSpan tempo = (DateTime.Now - veic.HoraEntrada);
            return tempo.Seconds * valorSegundos;
        }

        public double saidaVeiculo(string placa)
        {
            foreach (Veiculo veic in Estacionados)
            {
                if (!veic.Placa.Equals(placa)) continue;
                var valor = calcularValor(veic);
                Estacionados.Remove(veic);
                return valor;
            }

            return -1;
        }

        public void listarVeiculos()
        {
            foreach (Veiculo veic in Estacionados)
                Console.WriteLine(veic.Placa);
        }

        public Veiculo buscarVeiculo(string placa)
        {
            foreach (Veiculo veic in Estacionados)
            {
                if (veic.Placa.Equals(placa))
                {
                    return veic;
                }
            }
            return default(Veiculo);
        }

        public bool placaValida(string placa)
        {
            bool achouNum = false, achouLet = false;
            foreach (char t in placa)
            {
                if (char.IsNumber(t)) achouNum = true;
                else achouLet = true;
            }
            if (achouNum && achouLet)
                return true;
            return false;
        }
    }
}
