
using System.Collections.Generic;

namespace ProjetoModeloDDDv.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {

        // Aqui é listado os métodos e suas funcionalidades,
        // mas é apenas a interface para outra classe que realmente vai aplicar essas funcionalidades
        // O TEntidy é pq eu não sei o que vou receber, então chamei de TEntity, mas podia colocar qualquer nome
        // Note: Eles são apenas o contrato que ele deve fazer.

        // método adicionar, onde ele recebe um obj qualquer nos parametros. Não retorna nada.
        void add(TEntity obj);

        // Método para pegar um elemento por id. Retorna a propria classe.
        TEntity GetById(int id);
        
        // Método para pegar todos os elementos. Retorna uma lista Enumerada
        IEnumerable<TEntity> GetAll();

        // Método para atualizar, onde ele recebe um obj qualquer nos parametros. Não retorna nada.
        void Update(TEntity obj);

        // Método que remove, onde ele recebe um obj qualquer nos parametros. Não retorna nada.
        void Remove(TEntity obj);

        void Dispose();

    }
}
