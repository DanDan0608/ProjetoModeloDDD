using ProjetoModeloDDDv.Domain.Entities;

namespace ProjetoModeloDDDv.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {

        // Aqui ele apenas herda os métodos do repository base, e criar métodos próprios para o cliente;

    }
}
