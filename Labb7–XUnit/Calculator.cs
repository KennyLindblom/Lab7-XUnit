using Labb7_XUnit.Data;
using Labb7_XUnit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7_XUnit
{
    public class Calculator
    {
        public int Add(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine($"{num1} + {num2} = {sum}");

            CalculationLog log = new CalculationLog
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Operation = "+",
                Result = sum,
                Date = DateTime.Now
            };

            using (var dbContext = new CalculatorDbContext())
            {
                dbContext.CalculationLog.Add(log);
                dbContext.SaveChanges();
            }

            return sum;
        }

        public int Subtract(int num1, int num2)
        {
            int difference = num1 - num2;
            Console.WriteLine($"{num1} - {num2} = {difference}");


            CalculationLog log = new CalculationLog
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Operation = "-",
                Result = difference,
                Date = DateTime.Now
            };

            
            using (var dbContext = new CalculatorDbContext())
            {
                dbContext.CalculationLog.Add(log);
                dbContext.SaveChanges();
            }

            return difference;
        }


        public int Divide(int num1, int num2)
        {
            if(num2 == 0)
            {
                Console.WriteLine("Can not divide by zero");

                return 0;
            }

            int quotient = num1 / num2;
            Console.WriteLine($"{num1} / {num2} = {quotient}");

            CalculationLog log = new CalculationLog
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Operation = "/",
                Result = quotient,
                Date = DateTime.Now
            };

            using (var dbContext = new CalculatorDbContext())
            {
                dbContext.CalculationLog.Add(log);
                dbContext.SaveChanges();
            }

            return quotient;
        }


        public int Multiply(int num1, int num2)
        {
            int product = num1 * num2;
            Console.WriteLine($"{num1} * {num2} = {product}");

            CalculationLog log = new CalculationLog
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Operation = "*",
                Result = product,
                Date = DateTime.Now
            };

            using (var dbContext = new CalculatorDbContext())
            {
                dbContext.CalculationLog.Add(log);
                dbContext.SaveChanges();
            }

            return product;
        }

    }
}
