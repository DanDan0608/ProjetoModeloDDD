
using ProjetoModeloDDD.Infra.Data.Contexto;
using ProjetoModeloDDDv.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetoModeloDDDv.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        // Criando uma instancia do ProjetoModeloContext();
        protected ProjetoModeloContext Db = new ProjetoModeloContext();

        // Aqui eu puxei todos os métodos da interface "IRepositoryBase",
        // e é onde vou realmente implementar as funcionalidades

        public void add(TEntity obj)
        {

            // Estou setando no "ProjetoModeloContext" o TEntity e add ele
            Db.Set<TEntity>().Add(obj);

            // Aqui eu chamo o método "SaveChanges()" que eu fiz no "ProjetoModeloContext" 
            Db.SaveChanges();

        }

        public void Dispose()
        {
            
        }

        public IEnumerable<TEntity> GetAll()
        {
            // aqui eu retorno uma Lista de tudo do TEntity.
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            // Aqui eu retorno o que ele achar no id que eu passar como parametro para o TEntity
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            // Aqui eu removo o obj que eu estou passando para o TEntity
            Db.Set<TEntity>().Remove(obj);

            // Aqui eu chamo o método "SaveChanges()" que eu fiz no "ProjetoModeloContext" 
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            //Aqui eu entro com um Obj e modifico ele.
            Db.Entry(obj).State = EntityState.Modified;

            // Aqui eu chamo o método "SaveChanges()" que eu fiz no "ProjetoModeloContext" 
            Db.SaveChanges();
        }
    }
}
