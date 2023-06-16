using Labb7_XUnit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7_XUnit.Data
{
    public class CalculatorDbContext : DbContext
    {
        public DbSet<CalculationLog> CalculationLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = KENNYLINDBLOM;database = CalculatorLabb7;Trusted_Connection = True; TrustServerCertificate = true;");
        }
        public static void DeleteAllCalculations()
        {
            using (var dbContext = new CalculatorDbContext())
            {
                var calculationLogs = dbContext.CalculationLog.ToList();
                dbContext.CalculationLog.RemoveRange(calculationLogs);
                dbContext.SaveChanges();
            }
        }
    }

}
