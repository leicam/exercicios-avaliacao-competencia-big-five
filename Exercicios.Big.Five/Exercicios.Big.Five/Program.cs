using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercicios.Big.Five
{
    public class Program
    {
        /// <summary>
        /// Implementado os seguintes algoritimos
        /// Breadth First Search
        /// Depth First Search (Grafos ainda não sei como funciona ficará para mais tarde) - 
        /// Binary Search (Busca Binária) - OK
        /// Merge Sort - 
        /// Quick Sort - OK
        /// </summary>
        /// <param name="args"></param>
        internal static void Main(string[] args)
        {
            ConsoleKeyInfo menu;
            do
            {

                Console.WriteLine("Selecione um algoritimo para executar: ");
                Console.WriteLine("Breadth First Search - Digite 1");
                Console.WriteLine("Depth First Search - Digite 2");
                Console.WriteLine("Binary Search - Digite 3");
                Console.WriteLine("Merge Sort - Digite 4");
                Console.WriteLine("Quick Sort - Digite 5");

                menu = Console.ReadKey();

                switch (menu.Key)
                {
                    case ConsoleKey.NumPad1:
                        ExecutarBreadthFirstSearch();
                        break;
                    case ConsoleKey.NumPad2:
                        break;
                    case ConsoleKey.NumPad3:
                        ExecutarBinarySearch();
                        break;
                    case ConsoleKey.NumPad4:
                        ExecutarMergeSort();
                        break;
                    case ConsoleKey.NumPad5:
                        ExecutarQuickSort();
                        break;
                    default:
                        Console.WriteLine("Opção inválida verifique!");
                        break;
                }

            } while (ConsoleKey.S.Equals(menu.Key));
        }


        private static void ExecutarBreadthFirstSearch()
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("Executando algoritimo Breadth First Search");

                var tabela = new Hashtable();

                tabela.Add("Juliano", new string[] { "Monique", "Juarez", "Elizabete", "Sabrina", });
                tabela.Add("Sabrina", new string[] { "Saint", "Jean", "Lino", "Aparecida", });
                tabela.Add("Saint", new string[] { "Clara", "Barbara", });
                tabela.Add("Jean", new string[] { "Brian" });
                tabela.Add("Clara", new string[0]);
                tabela.Add("Brian", new string[0]);

                Console.WriteLine($"{BradthFirstSearch(tabela, "Juliano")}");
                Console.WriteLine("\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n");
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
                Console.WriteLine("\n");
                Console.WriteLine("Executando algoritimo Merge Sort");
                Console.WriteLine("\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }
                
        private static void ExecutarQuickSort()
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("Executando algoritimo Quick Sort");

                var array = new int[] { 9, 1, 7, 3, 5 };

                Console.WriteLine($"Array pré ordernação: {ObterDadosArray(array)}");
                Console.WriteLine($"Array pós ordernação: {ObterDadosArray(QuickSort(array))}");
                Console.WriteLine("\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }

        private static void ExecutarBinarySearch()
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("Executando algoritimo Binary Search (Busca Binária)");

                var array = new int[] { 1, 3, 5, 7, 9 };
                var item = 3;

                Console.WriteLine($"Indice no array é, {BinarySearch(array, item)}");
                Console.WriteLine("\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Breadth First Search ou Pesquisa em Largura é um algoritimo composto por grafos.
        /// Cada grafos é constituido de versices e arestas.
        /// O algoritmo em si, responde a duas questões:
        ///  existe um caminho do vertice A ate o vertice B?
        ///  qual o menor caminho entre o vertice A ate o vertice B?
        /// </summary>
        public static string BradthFirstSearch(Hashtable tabela, string verticeInicial)
        {
            var fila = new Queue();
            var verificados = new List<string>();

            Enfileirar(ref fila, tabela[verticeInicial] as string[]);

            while (fila.Count > 0)
            {
                var pessoa = fila.Dequeue() as string;

                if (IsVendedor(pessoa))
                    return $"{pessoa} é um(a) vendedor(a)";

                if (verificados.Contains(pessoa))
                    continue;

                Enfileirar(ref fila, tabela[pessoa] as string[]);
                verificados.Add(pessoa);
            }

            throw new ArgumentException("Não foi encontrado um vendedor na pesquisa!");
        }

        private static void Enfileirar(ref Queue fila, string[] lista)
        {
            if (lista == null)
                return;

            foreach (var item in lista)
                fila.Enqueue(item);
        }

        private static bool IsVendedor(string pessoa)
            => "Barbara".Equals(pessoa.Trim());

        /// <summary>
        /// Este algoritimo tem como objetivo, encontrar uma posição no array da maneira mais performatica possivel
        /// Funciona apenas quando a  lista está ordenada
        /// Retorna a posição do item pesquisado no array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int BinarySearch(int[] array, int item)
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

        public static string ObterDadosArray(int[] array)
        {
            var dados = string.Empty;

            foreach (var item in array)
                dados += $"{item}, ";

            return dados;
        }

        /// <summary>
        /// Este é um algoritimo de ordenação que utiliza a técnica dividir para conquistar
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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
