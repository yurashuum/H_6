using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework_6
{
     class Program
    {

        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Справочник сотрудников");
            Thread.Sleep(2000);
            Console.WriteLine("Введите цифру запроса, который вам требуется");
            Thread.Sleep(3000);
            Console.WriteLine("1 - выведет данные файла \n2 - позволяет заполнить файл");

            
            int number = int.Parse(Console.ReadLine());

            if (number == 2) {

                using (StreamWriter swDirect = new StreamWriter("Справочник.csv", true, Encoding.Unicode))
                {
                    char key = '2';
                    do
                    {
                        string id = string.Empty;
                        Console.Write("/nВведите айди");
                        id += $"{Console.ReadLine()}#";

                        DateTime date = DateTime.Now;
                        Console.WriteLine($"Время заполнения:{date}");
                        id += $"{date}#";

                        Console.WriteLine("Введите ФИО");
                        string fullName = $"{Console.ReadLine()}";
                        id += $"{fullName}#";


                        Console.WriteLine("Введите возраст");
                        int age = int.Parse(Console.ReadLine());
                        id += $"{age}#";

                        Console.WriteLine("Введите свой рост");
                        int height = int.Parse(Console.ReadLine());
                        id += $"{height}#";

                        Console.WriteLine("Введите дату рождения");
                        string wasborn = $"{Console.ReadLine()}";
                        id += $"{wasborn}#";

                        Console.WriteLine("Введите место рождения");
                        string home = $"{Console.ReadLine()}";
                        id += $"{home}";

                        swDirect.WriteLine(id, date, fullName, age, height, wasborn, home);

                       

                        Console.Write("Продолжить 1/2"); key = Console.ReadKey(true).KeyChar;

                    } while (char.ToLower(key) == '2');



                }
            }
            
            


                if (number == 1)

            {
                string file = @"C:\Users\Ксения\source\repos\Homework_6\Homework_6\bin\Debug\Справочник.csv";
                    FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Exists)

                {

                    using (StreamReader readDirectory = new StreamReader("Справочник.csv"))
                    {

                        while (!readDirectory.EndOfStream)
                        {
                            string[] elements = readDirectory.ReadLine().Split('#');
                            Console.WriteLine($"Id: {elements[0]} Время: {elements[1]} ФИО: {elements[2]} Возраст: {elements[3]} Рост: {elements[4]} Дата рождения: {elements[5]} Город: {elements[6]}");
                        }

                    }
                }

                else {
                    Console.WriteLine($"Файл ещё не создан"); 
                }
            }

            Console.ReadKey();
        }
    } 
}
