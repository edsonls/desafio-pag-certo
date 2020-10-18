using DesafioPagCerto.Repository.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPagCerto.Repository.EntityFramework.Drive
{
    public class Drive : DbContext
    {
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Installment> Installment { get; set; }
        public DbSet<Anticipation> Anticipation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=DesafioPagCertoDB;User Id=sa;Password=#SENHA_carga;");
        }
    }
}