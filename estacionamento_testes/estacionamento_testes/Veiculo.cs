using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamento_testes
{
    public class Veiculo
    {
        private string placa;
        private DateTime horaEntrada;

        public string Placa { get => placa; set => placa = value; }
        public DateTime HoraEntrada { get => horaEntrada; set => horaEntrada = value; }

        public Veiculo(string _placa)
        {
             Placa = _placa;
        }
    }
}
