using ProjetoModeloDDDv.Application.Interface;
using ProjetoModeloDDDv.Domain.Entities;
using ProjetoModeloDDDv.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ProjetoModeloDDDv.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {

        private readonly IClienteService _clienteService;   

        public ClienteAppService(IClienteService clienteService) : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        }
    }
}
