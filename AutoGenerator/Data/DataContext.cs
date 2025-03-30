
using Microsoft.EntityFrameworkCore;
using AutoGenerator.Models;

namespace AutoGenerator.Data
{
  public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
