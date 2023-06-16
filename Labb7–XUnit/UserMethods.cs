using Labb7_XUnit.Data;
using Labb7_XUnit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7_XUnit
{
    public class UserMethods
    {

        public static void MainMenu()
        {
            Calculator calculator = new Calculator();

            int num1;
            int num2;

            bool exitMenu = false;

            while(!exitMenu)
            {
                Console.WriteLine("Press any key to procced");
                Console.ReadKey();
                Console.Clear();

                string[] menuItems = { "Addition", "Subtraction", "Division", "Multiplication", "Get all Calculations", "Remove all calculations", "Exit" };
                int selectedIndex = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Calculator 20000");
                    Console.WriteLine("-----------------------------");

                    for (int i = 0; i < menuItems.Length; i++)
                    {
                        if (selectedIndex == i)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(menuItems[i]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine(menuItems[i]);
                        }
                    }

                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedIndex--;
                            if (selectedIndex < 0)
                            {
                                selectedIndex = menuItems.Length - 1;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            selectedIndex++;
                            if (selectedIndex == menuItems.Length)
                            {
                                selectedIndex = 0;
                            }
                            break;
                        case ConsoleKey.Enter:
                            switch (menuItems[selectedIndex])
                            {
                                case "Addition":
                                    GetUserInput(out num1, out num2);
                                    int sum = calculator.Add(num1, num2);
                                    SaveCalculations(num1, num2, "+");
                                    Console.ReadKey();
                                    break;


                                case "Subtraction":
                                    GetUserInput(out num1, out num2);
                                    int sub = calculator.Subtract(num1, num2);
                                    SaveCalculations(num1, num2, "-");
                                    Console.ReadKey();
                                    break;


                                case "Division":
                                    GetUserInput(out num1, out num2);
                                    int div = calculator.Divide(num1, num2);
                                    SaveCalculations(num1, num2, "/");
                                    Console.ReadKey();
                                    break;


                                case "Multiplication":
                                    GetUserInput(out num1, out num2);
                                    int mult = calculator.Multiply(num1, num2);
                                    SaveCalculations(num1, num2, "*");
                                    Console.ReadKey();
                                    break;

                                case "Get all Calculations":
                                    PrintAllCalculations();
                                    break;

                                case "Remove all calculations":
                                    CalculatorDbContext.DeleteAllCalculations();
                                    Console.WriteLine("All calculations have been deleted.");
                                    Console.ReadKey();

                                    break;

                                case "Exit":
                                    exitMenu = true;
                                    Console.WriteLine("Good bye");
                                    break;


                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    if (exitMenu)
                        break;
                    
                }




                }


        }

        public static void GetUserInput(out int num1, out int num2)
        {
            Console.WriteLine("Enter number :");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number :");
            num2 = int.Parse(Console.ReadLine()); ;

        }


        public static void PrintAllCalculations()
        {
            using (var dbContext = new CalculatorDbContext())
            {
                var calculationLogs = dbContext.CalculationLog.ToList();

                Console.WriteLine("Calculation Log");
                Console.WriteLine("----------------");

                HashSet<string> printedLogs = new HashSet<string>(); 

                foreach (var log in calculationLogs)
                {
                    int result;

                    
                    switch (log.Operation)
                    {
                        case "+":
                            result = log.FirstNumber + log.SecondNumber;
                            break;
                        case "-":
                            result = log.FirstNumber - log.SecondNumber;
                            break;
                        case "/":
                            result = log.FirstNumber / log.SecondNumber;
                            break;
                        case "*":
                            result = log.FirstNumber * log.SecondNumber;
                            break;
                        default:
                            result = 0; 
                            break;
                    }

                    string logText = $"{log.FirstNumber} {log.Operation} {log.SecondNumber} = {result}  ({log.Date})";

                    if (!printedLogs.Contains(logText))
                    {
                        Console.WriteLine(logText);
                        printedLogs.Add(logText); 
                    }
                }
                Console.ReadKey();
            }
        }




        public static void SaveCalculations(int num1, int num2, string operation)
        {
            CalculationLog log = new CalculationLog
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Operation = operation,
                Date = DateTime.Now
            };

            using (var dbContext = new CalculatorDbContext())
            {
                dbContext.CalculationLog.Add(log);
                dbContext.SaveChanges();
            }
        }

        



    }

}

