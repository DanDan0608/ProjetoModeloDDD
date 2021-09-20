
using ProjetoModeloDDDv.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDDv.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            // definindo que o Cliente Id é a chave primária (Mesmo já tendo configurado isso em "ProjetoModeloContext")
            HasKey(c => c.CLienteId);

            // Definindo que o Nome da entidade Cliente é requirido (Obrigatorio) e pode ter no máximo 150 de tamanho
            // nota: Desobedecendo a regra que foi feita como default em "ProjetoModeloContex" de tamanho 100
            Property(c => c.Nome).IsRequired().HasMaxLength(150);

            // fazendo  a mesma coisa que a propriedade de cima
            Property(c => c.Sobrenome).IsRequired().HasMaxLength(150);

            // só definido que é requirido (Obrigatório), e o maxLength vai ficar o default que foi configurado
            Property(c => c.Email).IsRequired();
        }
    }
}
