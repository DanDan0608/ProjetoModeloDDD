using ProjetoModeloDDDv.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDDv.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {

        IEnumerable<Produto> BuscarPorNome(string nome);

    }
}
