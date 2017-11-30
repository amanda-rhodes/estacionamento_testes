using System;

namespace estacionamento_testes
{
    public class Veiculo
    {
        public string Placa { get; set; }

        public DateTime HoraEntrada { get; set; }

        public Veiculo(string placa)
        {
             Placa = placa;
        }
    }
}
