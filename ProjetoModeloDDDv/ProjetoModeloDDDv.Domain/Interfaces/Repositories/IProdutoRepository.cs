
using ProjetoModeloDDDv.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDDv.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        // Agora, além de implementar os métodos do "IRepositoryBase", estou criando um específico para apenas o Produto
        IEnumerable<Produto> BuscarPorNome(string nome);

    }
}
