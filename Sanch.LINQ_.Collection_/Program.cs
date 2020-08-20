using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.LINQ_.Collection_
{
    class Program
    {
        static void Main(string[] args)
        {
            #region One
            /*
            var collction = new List<int>();

            for (var i = 0; i < 10; i++)
            {
                collction.Add(i);
            }

            // У линка есть две формы записи
            // стандартная( покажая на SQL ) или методы расширения(?) - они позволяют добавлять методы в классы (повверх класса) без наследника

            //cтандартная

            var result = from item in collction where item < 5 select item;
            // в iten будут помещатсья все элементы коллекции по очереди
            // пишется условие как в SQl и выбор что мы хотим пихнуть в переменную

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            ////////////////////////////////////////////////////////////////////////

            // метод расширений
            var result2 = collction.Where(item => item < 5).Where(item => item % 2 == 0); // => - знак "Такой что" - айтем такой что айтем меньше 5
            //collction.Where(item => item < 5).и еще что то (еще условия) - как сосиска через точку

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            ////////////////////////////////////////////////////////////////////////
            */
            #endregion

            #region Two
            /*
            var rnd = new Random();

            var collection2 = new List<Product>();

            for (var i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Продукт" + i,
                    Energy = rnd.Next(10, 500) // от 10 до 500
                };
                collection2.Add(product);
            }
            var result = from item in collection2 where item.Energy < 200 select item;

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var result2 = collection2.Where(item => item.Energy < 200);

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            // в LINQ - Select для преобразования

            #region Free

            var rnd = new Random();

            var products = new List<Product>();

            for (var i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Продукт" + i,
                    Energy = rnd.Next(10, 12) // от 10 до 500
                };
                products.Add(product);
            }
            var result = from item in products where item.Energy < 200 /*orderby item.Energy groupby item.Energy*/ select item; //можно упорядочить

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var result2 = products.Where(item => item.Energy < 200);

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            //преобразование//////////////////////////////////////////////

            var selectCollection = products.Select(product => product.Energy); // преобразует коллекцию Product где име и счетчик каллорий , в просто счетчик каллорий
            // получилась коллекция целых чисел

            foreach (var item in selectCollection)
            {
                Console.WriteLine(item);
            }
            ///////////////////////////////////////////////////////////////

            Console.WriteLine();

            //упорядочить//////////////////////////////////////////////

            var orderbyCollection = products.OrderBy(product => product.Energy);
            //orderby - от меньшего к большему
            //OrderByDescending - от большего к меньшему

            foreach (var item in orderbyCollection)
            {
                Console.WriteLine(item);
            }
            //////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //дополнительно упорядочить//////////////////////////////////////////////

            var orderbyCollectionDop = products.OrderBy(product => product.Energy).ThenByDescending(product => product.Name);
            //Thenby - от меньшего к большему
            //ThenByDescending - от большего к меньшему

            foreach (var item in orderbyCollectionDop)
            {
                Console.WriteLine(item);
            }
            ///////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //группировка///////////////////////////////////////////////////////////

            var groupbyCollection = products.GroupBy(product => product.Energy);
            //список списков получилось

            foreach (var group in groupbyCollection)
            {
                Console.WriteLine($"Ключ: {group.Key}"); //Key - ключ группировки 
                foreach (var item in group)
                {
                    Console.WriteLine($"\t{item}");// \t - отступ
                }
                Console.WriteLine();
            }

            ///////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //реверс - перевернуть коллекцию в обратном порядке////////////////////////

            products.Reverse();
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            ///////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //All          ///////////////////////////////////////////////////////////////////
            //возвращает булевое значение true если все элементы списка проходят условие, или false если не все проходят элементы под условием 
            //Any          ///////////////////////////////////////////////////////////////////
            //возвращает булевое значение true если один элемент списка проходят условие

            var allCollection = products.All(item => item.Energy == 10);
            Console.WriteLine(allCollection);

            var anyCollection = products.Any(item => item.Energy == 10);
            Console.WriteLine(anyCollection);

            ///////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //Contains///////////////////////////////////////////////////////////////////
            //если элемент входит в коллекцию то возвращает тру
            //если из другой коллекции элемент сверяем с коллекцие продуктов, а там ее нет то фолсе

            var containsCollection = products.Contains(products[5]);
            Console.WriteLine(containsCollection);

            var prod = new Product();

            var containsCollectionNo = products.Contains(prod);
            Console.WriteLine(containsCollectionNo);

            ///////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //Distinct и Union и Intersect и Except и Sum И Min и Max и aggregate и skip и take///////////////////
            //Distinct удаляет повторки
            //Union - объединяет массивы без повторок
            //Intersect - выводит только пересечение (общее)
            //Except - то что не вошло в общее с первой коллекцией
            //Sum - сумма коллекции
            //Min и Max
            //aggregate - произведение коллекции
            //skip - пропуск элементов
            //take - сколько элементов нужно взять

            var array = new int[] { 1, 2, 3, 4 };
            var array2 = new int[] { 3, 4, 5, 6 };
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var union = array.Union(array2);
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //только что совпадает
            var intersect = array.Intersect(array2);
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //только то что не совпало в первой коллекции
            var except = array.Except(array2);
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //сумма коллекции
            var sum = array.Sum();
            Console.WriteLine(sum);
            Console.WriteLine();
            //минимальное в коллекции
            var min = array.Min();
            //var min= products.Min(p => p.Energy); по колличеству каллорий
            Console.WriteLine(min);
            Console.WriteLine();
            //максимальное в коллекции
            var max = array.Max();
            Console.WriteLine(max);
            Console.WriteLine();
            //произведение коллекции
            var aggregate = array.Aggregate((x, y) => x * y);
            Console.WriteLine(aggregate);
            Console.WriteLine();
            //часть коллекции
            var sum2 = array.Skip(2).Sum(); // пропуск двух первых эллементов
            Console.WriteLine(sum2);
            Console.WriteLine();
            //часть коллекции 2
            var sum3 = array.Skip(1).Take(2).Sum(); // берет два элемента и складывает после пропуска
            Console.WriteLine(sum3);
            //////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //ВЫБОРКА ЭЛЕМЕНТОВ///////////////////////////////////////////////////
            //first и last и single и elementAt///////////////////////////////////
            //first - берем первый элемент из коллекции (если коллекция не пустая)
            //firstordefault -если коллекция пустая 
            //last - берем последний элемент из коллекции  (если коллекция не пустая)
            //lastordefault -если коллекция пустая 
            //single - возвращает первый и единственный продукт под условием
            //singleordefault -если коллекция пустая
            //elementAt - по индексу выборка
            //elementAtordefault -если коллекция пустая

            var first = array.First();
            Console.WriteLine(first);
            Console.WriteLine();

            var last = array.Last();
            Console.WriteLine(last);
            Console.WriteLine();

            var single = array.Single(a => a == 3);
            Console.WriteLine(single);
            Console.WriteLine();

            var elementAt = array.ElementAt(3);
            Console.WriteLine(single);
            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////





            #endregion




            Console.ReadLine();

        }
    }
}
