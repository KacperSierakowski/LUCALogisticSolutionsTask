using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LUCALogisticSolutionsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string first, second, result;
            int firstLength, secondLength;
            string theEnd = "R";
            bool correctChoise = false;
            //File.WriteAllText("log.txt","");
            File.WriteAllText("log.txt", DateTime.Now.ToString() + " System: Uruchomienie programu." + Environment.NewLine);
            Thread thread1 = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(30000);
                    File.AppendAllText("log.txt", DateTime.Now + " System: keepAlive" + Environment.NewLine);
                }
            });
            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("Zadanie rekrutacyjne dla LUCA Logistic Solutions Sp. z o.o.");
                while (theEnd != "T")
                {
                    Console.WriteLine("Podaj pierwszy ciąg znaków: ");
                    first = Console.ReadLine();
                    firstLength = first.Length;
                    Console.WriteLine("Podaj drugi ciąg znaków: ");
                    second = Console.ReadLine();
                    secondLength = second.Length;
                    if (first == second)
                    {
                        result = "Ciągi są równe.";
                        Console.WriteLine(result);
                    }
                    else
                    {
                        if (firstLength == secondLength)
                        {
                            result = "Ciągi mają taka samą długość,ale różne znaki.";
                            Console.WriteLine(result);
                        }
                        else if (firstLength > secondLength)
                        {
                            result = "Ciągi pierwszy jest dłuższy.";
                            Console.WriteLine(result);
                        }
                        else
                        {
                            result = "Ciągi drugi jest dłuższy.";
                            Console.WriteLine(result);
                        }
                    }
                    File.AppendAllText("log.txt", DateTime.Now + " Ciąg 1: " + first + ", ciąg 2: " + second + ", wynik: " + result + Environment.NewLine);
                    while (correctChoise != true)
                    {
                        Console.WriteLine("Powtórz proces               - R");
                        Console.WriteLine("Zakończ działanie programu   - T");
                        theEnd = Console.ReadLine();
                        if (theEnd == "T")
                        {
                            File.AppendAllText("log.txt", DateTime.Now.ToString() + " System: Zakończenie pracy programu." + Environment.NewLine);
                            correctChoise = true;
                        }
                        else if (theEnd == "R")
                        {
                            File.AppendAllText("log.txt", DateTime.Now.ToString() + " System: Użytkownik potwierdził ponowne sprawdzenie." + Environment.NewLine);
                            correctChoise = true;
                        }
                        else
                        {
                            File.AppendAllText("log.txt", DateTime.Now.ToString() + " System: Podano złą odpowiedź przy zapytaniu o ponowne uruchomienie!" + Environment.NewLine);
                            Console.WriteLine("Podano złą odpowiedź!");
                            correctChoise = false;
                        }
                    }
                    correctChoise = false;
                }
                thread1.Abort();
            });
            thread1.Start();
            thread2.Start();
        }
    }
}
