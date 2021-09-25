using ProjetoModeloDDDv.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDDv.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {

        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> cliente);

    }
}
