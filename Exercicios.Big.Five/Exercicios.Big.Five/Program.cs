using System;
using System.Linq;

namespace Exercicios.Big.Five
{
    public class Program
    {
        /// <summary>
        /// Implementado os seguintes algoritimos
        /// Breadth First Search/Depth First Search (Grafos ainda não sei como funciona ficará para mais tarde) - 
        /// Binary Search (Busca Binária) - OK
        /// Merge Sort and Quick Sort -
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //ExecutarBuscaBinaria();
            //ExecutarMergeSort();
            ExecutarQuickSort();
        }

        private static void ExecutarBuscaBinaria()
        {
            try
            {
                Console.WriteLine("Executando algoritimo Binary Search (Busca Binária) \n");

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
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }

        private static void ExecutarMergeSort()
        {
            try
            {
                Console.WriteLine("Executando algoritimo Merge Sort \n");

            }
            catch(Exception ex)
            {
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
                
        private static void ExecutarQuickSort()
        {
            try
            {
                Console.WriteLine("Executando algoritimo Quick Sort \n");

                var array = new int[] { 9, 1, 7, 3, 5 };

                Console.WriteLine($"Array pré ordernação: {ObterDadosArray(array)}");

                Console.WriteLine($"Array pós ordernação: {ObterDadosArray(QuickSort(array))}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static string ObterDadosArray(int[] array)
        {
            var dados = string.Empty;

            foreach (var item in array)
                dados += $"{item}, ";

            return dados;
        }


        /// <summary>
        /// Este algoritimo tem como objetivo, encontrar uma posição no array da maneira mais performatica possivel
        /// Funciona apenas quando a  lista está ordenada
        /// Retorna a posição do item pesquisado no array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Este é um algoritimo de ordenação que utiliza a técnica dividir para conquistar
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static int[] QuickSort(int[] array)
        {
            if (array.Length < 2)
                return array;

            var indice = (array.Length - 1) / 2;
            var pivo = array[indice];
            var menores = array.Where(x => x < pivo).ToArray();
            var maiores = array.Where(x => x > pivo).ToArray();
            
            menores = QuickSort(menores);
            maiores = QuickSort(maiores);

            var resultado = new int[menores.Length + maiores.Length + 1];

            menores.CopyTo(resultado, 0);
            resultado[menores.Length] = pivo;
            maiores.CopyTo(resultado, menores.Length + 1);

            return resultado;
        }
    }
}
