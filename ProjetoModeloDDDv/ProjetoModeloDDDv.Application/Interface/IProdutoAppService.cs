using ProjetoModeloDDDv.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDDv.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {

        IEnumerable<Produto> BuscarPorNome(string nome);

    }
}
