using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace estacionamento_testes
{
    /*O atributo TestFixture é uma indicação de que uma classe contém métodos de teste
    /Quando você menciona esse atributo para uma classe em seu projeto
    /a aplicação Test Runner irá procurar por métodos de testes*/
    [TestFixture]
    class MyTestCase
    {
        /*O atributo de Test indica que um método dentro de um Testfixture deve ser executado 
        pela aplicação Test Runner. O método deve ser público e retornar void.*/
        [TestCase]
        public void novoVeiculoTrueTeste()
        {
            Estacionamento est = new Estacionamento(1);
            /*A classe Assert é usada para confirmar se os casos de testes estão 
            * produzindo o resultado esperado ou não usando métodos auxiliares 
            * como AreEqual() ou AreNotEqual().*/
            Assert.IsTrue(est.novoVeiculo("a", 10, 10));
        }

        [TestCase]
        public void novoVeiculoFalseTeste()
        {
            Estacionamento est = new Estacionamento(1);
            est.novoVeiculo("a", 10, 10);
            Assert.IsFalse(est.novoVeiculo("b", 10, 10));
        }

        [TestCase]
        public void novoVeiculoHorarioInvalido()
        {
            Estacionamento est = new Estacionamento(1);
            int hora = 25;
            int min = 60;
            Assert.AreEqual(true, est.novoVeiculo("b", hora, min));
        }

        [TestCase]
        public void cheioTrueTeste()
        {
            Estacionamento est = new Estacionamento(1);
            est.novoVeiculo("a", 10, 10);
            Assert.IsTrue(est.cheio());
        }

        [TestCase]
        public void cheioFalseTeste()
        {
            Estacionamento est = new Estacionamento(2);
            est.novoVeiculo("a", 10, 10);
            Assert.IsFalse(est.cheio());
        }
    }
}
