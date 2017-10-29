using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamento_testes
{
    public class Estacionamento
    {
        private int numVagas;
        private List<Veiculo> estacionados;
        private const double valorSegundos = 3.50;

        public int NumVagas { get => numVagas; set => numVagas = value; }
        public List<Veiculo> Estacionados { get => estacionados; set => estacionados = value; }

        public static double ValorHora => valorSegundos;

        public Estacionamento(int _numVagas)
        {
            if (_numVagas < 1)
                throw new Exception("o valor do parâmentro não pode ser menor do que 1 (um)");
            else
            {
                NumVagas = _numVagas;
                Estacionados = new List<Veiculo>();
            }
        }

        public bool cheio()
        {
            if (Estacionados.Count == NumVagas) return true;
            return false;
        }

        public bool novoVeiculo(string placa, int hora, int minutos)
        {
            try
            {
                if (string.IsNullOrEmpty(placa))
                    throw new ArgumentNullException(placa, "o valor do parâmetro não pode ser null");
                else if (hora < 0 || hora > 23)
                    throw new Exception("o valor do parâmentro não pode ser negativo ou maior que 23");
                else if (minutos < 0 || minutos > 59)
                    throw new Exception("o valor do parâmentro não pode ser negativo ou maior que 59");
                else
                {
                    Veiculo novo = new Veiculo(placa);
                    novo.HoraEntrada = new DateTime(1, 1, 1, hora, minutos, 0);

                    if (cheio() == false)
                    {
                        novo.HoraEntrada = DateTime.Now;
                        Estacionados.Add(novo);
                        return true;
                    }
                }
                return false;
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
            double valor = 0;
            foreach (Veiculo veic in Estacionados)
            {
                if (veic.Placa.Equals(placa))
                {
                    valor = calcularValor(veic);
                    estacionados.Remove(veic);
                    return valor;
                }
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
    }
}
