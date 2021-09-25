using ProjetoModeloDDDv.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDDv.Application.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {

        IEnumerable<Cliente> ObterClientesEspeciais();

    }
}
