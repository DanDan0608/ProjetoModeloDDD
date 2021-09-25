using ProjetoModeloDDDv.Domain.Entities;
using ProjetoModeloDDDv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoModeloDDDv.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        // Aqui eu só tenho que implementar a interface do IProdutoRepository,
        // pois o IRepositoryBase já está sendo implementado no RepositoryBase
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            // Vou retornar todos os produtos onde o nome do produto seja igual o nome que o método recebeu no parametro.
            return Db.Produtos.Where(p => p.Nome == nome);
        }
    }
}
