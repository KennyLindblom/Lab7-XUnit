using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7_XUnit.Models
{
    public class CalculationLog
    {
        public int Id { get; set; }

        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public string Operation { get; set; }

        public int Result { get; set; }

        public DateTime Date { get; set; }
    }
}
