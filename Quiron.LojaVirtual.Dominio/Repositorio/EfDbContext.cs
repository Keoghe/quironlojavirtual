using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Quiron.LojaVirtual.Dominio.Entidade;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    //É a Class que receberá todos os DbSet
    public class EfDbContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }
        //Sobrescrevendo métodos
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
        }

    }
    
}
