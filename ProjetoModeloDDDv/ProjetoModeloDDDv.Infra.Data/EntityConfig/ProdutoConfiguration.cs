
using ProjetoModeloDDDv.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDDv.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            // Definindo o ProdutoId como chave 
            HasKey(p => p.ProdutoID);

            // Definindo que o Nome do produto é requirido (Obrigatorio) e pode ter no máximo 250 de tamanho
            // nota: Desobedecendo a regra que foi feita como default em "ProjetoModeloContex" de tamanho 100
            Property(p => p.Nome).IsRequired().HasMaxLength(250);

            // o valor do produto é requirido (obrigatorio)
            Property(p => p.Valor).IsRequired();

            // Ele é requirido, onde o Cliente pode ter vários produtos, referenciando o ClienteId como FK
            HasRequired(p => p.Cliente).WithMany().HasForeignKey(p => p.ClienteId);
        }

    }
}
