
using AutoMapper;
using ProjetoModeloDDDv.Application.Interface;
using ProjetoModeloDDDv.Domain.Entities;
using ProjetoModeloDDDv.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoModeloDDDv.MVC.Controllers
{
    public class ClientesController : Controller
    {

        // A controller, como o nome já diz, controla oq a página web faz
        // Se comunicando com a camada de application

        private readonly IClienteAppService _clienteApp;

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }


        // Por exemplo, quando ele entrar no index, ele vai Trazer tudo que estiver em Clientes
        // GET: Clientes
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());
            return View(clienteViewModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id) 
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {

            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterClientesEspeciais());

            return View(clienteViewModel);

        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // Quando ele clicar em "create", ele vai adicionar um Cliente
        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {

            if (ModelState.IsValid) 
            {

                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);

                _clienteApp.add(clienteDomain);

                return RedirectToAction("Index");
            
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(ClienteViewModel cliente) 
        {

            if (ModelState.IsValid) 
            {

                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Update(clienteDomain);

                return RedirectToAction("Index");
            
            }

            return View(cliente);
        
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id) 
        {

            var cliente = _clienteApp.GetById(id);
            _clienteApp.Remove(cliente);

            return RedirectToAction("Index");

        }

    }
}
