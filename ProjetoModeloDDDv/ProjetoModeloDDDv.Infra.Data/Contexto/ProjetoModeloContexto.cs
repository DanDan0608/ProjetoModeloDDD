using ProjetoModeloDDDv.Domain.Entities;
using ProjetoModeloDDDv.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    public class ProjetoModeloContext : DbContext
    {

        public ProjetoModeloContext()
            : base("ProjetoModeloDDD")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // remove a pluralização das tablelas, pois ele faz isso default
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Para ele não deletar em cascata em "um para muitos"
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Para ele não deletar em cascata em relação "muitos para muitos"
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Configura tudo que tiver "Id" no final, como uma primary key
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            // Configura tudo que for do tipo "string" para um "varchar" e não "nvarchar" do default
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            // Configura tudo que for do tipo "string" para o tamanho "100" se o tamanho nn for informado
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            // Aqui eu falo para ele usar as configurações feitas em "ClienteConfiguration"
            modelBuilder.Configurations.Add(new ClienteConfiguration());

            // Aqyu ey falo para ele usar as configurações feitar em "ProdutoConfiguration"
            modelBuilder.Configurations.Add(new ProdutoConfiguration());

        }

        public override int SaveChanges()
        {
            // para cada vez que eles for Trackear mudanças e ver que a propriedade "DataCadastro" == null
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Data Cadastro") != null))
            {

                // se tiver Adicionando, pega o horário daquele momento e joga para a propriedade
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                // se estiver modificando, não faz nada com a propriedade.
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}