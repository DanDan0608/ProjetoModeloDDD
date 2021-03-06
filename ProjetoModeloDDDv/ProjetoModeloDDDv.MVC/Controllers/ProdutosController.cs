using AutoMapper;
using ProjetoModeloDDDv.Application.Interface;
using ProjetoModeloDDDv.Domain.Entities;
using ProjetoModeloDDDv.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoModeloDDDv.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        private readonly IProdutoAppService _produtoApp;

        public ProdutosController(IProdutoAppService produtoApp, IClienteAppService clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
        }

        private readonly IClienteAppService _clienteApp;

        public ActionResult Index()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());

            return View(produtoViewModel);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(ProdutoViewModel produto)
        {

            if (ModelState.IsValid) 
            {

                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.add(produtoDomain);

                return RedirectToAction("Index");
            
            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteID);
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.Nome);
            return View(produto);

        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteID);
            //ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.Nome);

            return View(produtoViewModel);

        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {

                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");

            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteID);
            //ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.Nome);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        public ActionResult DeleteConfirmed(int id) 
        {

            var produto = _produtoApp.GetById(id);
            _produtoApp.Remove(produto);

            return RedirectToAction("Index");
        
        }

    }
}
