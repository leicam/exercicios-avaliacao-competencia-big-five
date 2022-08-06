using System;

namespace Exercicios.Big.Five
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExecutarBuscaBinaria();
        }

        /// <summary>
        /// Este algoritimo tem como objetivo, encontrar uma posição no array da maneira mais performatica possivel
        /// Funciona apenas quando a  lista está ordenada
        /// Retorna a posição do item pesquisado no array
        /// </summary>
        public static void ExecutarBuscaBinaria()
        {
            try
            {
                Console.WriteLine("Executando algoritimo de busca binária \n");

                var array = new int[] { 1, 3, 5, 7, 9 };
                var item = 3;

                Console.WriteLine($"Indice no array é, {BuscaBinaria(array, item)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static int BuscaBinaria(int[] array, int item)
        {
            var inicio = 0;
            var final = array.Length - 1;
            var contador = 0;

            while (inicio <= final && contador <= array.Length)
            {
                var indice = (inicio + final) / 2;
                var itemPesquisado = array[indice];

                if (item == itemPesquisado)
                    return indice;

                if (itemPesquisado < item)
                    inicio = indice++;
                else
                    final = indice--;

                contador++;
            }

            throw new ArgumentException("Indice não encontrado ou dados do array não estão ordenados em ordem crescente! Verifique.");
        }
    }
}
