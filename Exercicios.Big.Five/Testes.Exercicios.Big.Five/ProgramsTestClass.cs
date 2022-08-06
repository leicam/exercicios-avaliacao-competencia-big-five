using Exercicios.Big.Five;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testes.Exercicios.Big.Five
{
    [TestClass]
    public class ProgramsTestClass
    {
        private const string c_owner = "Juliano Riobeiro de Souza Maciel";
        private const string c_category = "Program";

        [TestMethod]
        [Owner(c_owner)]
        [TestCategory(c_category)]
        public void BuscaBinaria_DadosValidos_Sucesso()
        {
            Assert.AreEqual(3, Program.BuscaBinaria(new int[] { 1, 2, 3, 4, 5, 6 }, 4));
        }

        [TestMethod]
        [Owner(c_owner)]
        [TestCategory(c_category)]
        public void BuscaBinaria_ArrayNaoOrdenado_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => Program.BuscaBinaria(new int[] { 6, 1, 5, 2, 3, 4 }, 4));
        }

        [TestMethod]
        [Owner(c_owner)]
        [TestCategory(c_category)]
        public void BuscaBinaria_ArrayNaoPossuiItemPesquisado_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => Program.BuscaBinaria(new int[] { 1, 2, 3, 4, 5, 6 }, 10));
        }
    }
}
