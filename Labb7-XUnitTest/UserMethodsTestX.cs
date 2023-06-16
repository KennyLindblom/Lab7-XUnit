using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Labb7_XUnit;
using Labb7_XUnit.Data;
using Labb7_XUnit.Models;
using Microsoft.Identity.Client;
using Xunit;

namespace Labb7_XUnit_Test
{
    public class UserMethodsTestX
    {
        [Fact]
        public void GetUserInput_Reads_Correct_Input()
        {
            // Arrange
            int num1, num2;
            string input = "10\n5\n"; // Ange inmatningssträngen här

            using (StringReader reader = new StringReader(input))
            {
                Console.SetIn(reader);

                // Act
                UserMethods.GetUserInput(out num1, out num2);

                // Assert
                Assert.Equal(10, num1);
                Assert.Equal(5, num2);
            }

            
           
        }

        [Fact]
        public void SaveCalculations_AddCalculationToDatabase()
        {
            Calculator calculator = new Calculator();

            int num1 = 2;
            int num2 = 3;
            string Operation = "+";

            UserMethods.SaveCalculations(num1, num2, Operation);


            using (var dbContext = new CalculatorDbContext())
            {
                var calculationLogs = dbContext.CalculationLog.ToList();

                var calculation = calculationLogs[0];
                Assert.Equal(num1, calculation.FirstNumber); 
                Assert.Equal(num2, calculation.SecondNumber); 
                Assert.Equal(Operation, calculation.Operation); 
            }
        }

        








    }
}
