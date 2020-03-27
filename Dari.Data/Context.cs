//using Dari.Data.Configurations;
//using Dari.Data.Conventions;
using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Data
{
    public class Context : DbContext
    {

        public Context() : base("name=MaChaine")
        {

        }
        public virtual DbSet<Annonce> Annonces { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Meuble> Meuble { get; set; }
        public virtual DbSet<Abonnement> Abonnements { get; set; }
        public virtual DbSet<TyAbo> TyAbos { get; set; }

    





        /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {

             modelBuilder.Conventions.Add(new DateTime2());
             modelBuilder.Conventions.Add(new StringConvention());
             modelBuilder.Configurations.Add(new CategoryConfiguration());
             modelBuilder.Configurations.Add(new ProductConfiguration());
             modelBuilder.Configurations.Add(new FactureConfiguration());
         }*/

    }


}
