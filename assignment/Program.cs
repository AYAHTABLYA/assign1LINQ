using System;
using System.Linq;
using DemoG01.Data;   

namespace assignment

{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine(" Products that are out of stock:");
            var q1 = ListGenerator.ProductList
                .Where(p => p.UnitsInStock == 0);
            foreach (var p in q1)
                Console.WriteLine(p.ProductName);

            Console.WriteLine("\n Products that are in stock and cost more than 3:");
            var q2 = ListGenerator.ProductList
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            foreach (var p in q2)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

            Console.WriteLine("\n Digits whose name is shorter than their value:");
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q3 = digits
                .Select((word, index) => new { word, index })
                .Where(x => x.word.Length < x.index)
                .Select(x => x.word);
            foreach (var d in q3)
                Console.WriteLine(d);



            Console.WriteLine("\n Sort products by name:");
            var q4 = ListGenerator.ProductList
                .OrderBy(p => p.ProductName);
            foreach (var p in q4)
                Console.WriteLine(p.ProductName);

            Console.WriteLine("\nCase-insensitive sort of words:");
            string[] words1 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q5 = words1.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in q5)
                Console.WriteLine(w);

            Console.WriteLine("\nSort products by units in stock (desc):");
            var q6 = ListGenerator.ProductList
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var p in q6)
                Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");

            Console.WriteLine("\nSort digits by length then name:");
            string[] digits2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q7 = digits2
                .OrderBy(d => d.Length)
                .ThenBy(d => d);
            foreach (var d in q7)
                Console.WriteLine(d);

            Console.WriteLine("\nSort words by length then case-insensitive:");
            string[] words2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q8 = words2
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in q8)
                Console.WriteLine(w);

            Console.WriteLine("\n Sort products by category then by price desc:");
            var q9 = ListGenerator.ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            foreach (var p in q9)
                Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");

            Console.WriteLine("\n Sort words by length then case-insensitive descending:");
            string[] words3 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q10 = words3
                .OrderBy(w => w.Length)
                .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in q10)
                Console.WriteLine(w);

            Console.WriteLine("\n Digits with second letter 'i', reversed:");
            string[] digits3 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q11 = digits3
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse();
            foreach (var d in q11)
                Console.WriteLine(d);




            Console.WriteLine("\n Return only product names:");
            var q12 = ListGenerator.ProductList
                .Select(p => p.ProductName);
            foreach (var p in q12)
                Console.WriteLine(p);

            Console.WriteLine("\n Uppercase and lowercase words:");
            string[] words4 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var q13 = words4
                .Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            foreach (var w in q13)
                Console.WriteLine($"{w.Upper} / {w.Lower}");

            Console.WriteLine("\n Select some product properties (UnitPrice renamed to Price):");
            var q14 = ListGenerator.ProductList
                .Select(p => new { p.ProductName, Price = p.UnitPrice, p.Category });
            foreach (var p in q14)
                Console.WriteLine($"{p.ProductName} - {p.Price} - {p.Category}");

            Console.WriteLine("\n Value matches its position:");
            int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q15 = arr
                .Select((num, index) => new { num, index })
                .Where(x => x.num == x.index)
                .Select(x => x.num);
            foreach (var n in q15)
                Console.WriteLine(n);

            Console.WriteLine("\n Pairs where number from A < number from B:");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var q16 = numbersA
                .SelectMany(a => numbersB, (a, b) => new { a, b })
                .Where(pair => pair.a < pair.b);
            foreach (var pair in q16)
                Console.WriteLine($"{pair.a} < {pair.b}");

            Console.WriteLine("\n Orders with total < 500:");
            var q17 = ListGenerator.CustomerList
                .SelectMany(c => c.Orders)
                .Where(o => o.Total < 500);
            foreach (var o in q17)
                Console.WriteLine($"{o.OrderID} - {o.Total}");

            Console.WriteLine("\n Orders made in 1998 or later:");
            var q18 = ListGenerator.CustomerList
                .SelectMany(c => c.Orders)
                .Where(o => o.OrderDate.Year >= 1998);
            foreach (var o in q18)
                Console.WriteLine($"{o.OrderID} - {o.OrderDate.ToShortDateString()}");

            Console.WriteLine("\n All queries done!");
        }
    }
}
