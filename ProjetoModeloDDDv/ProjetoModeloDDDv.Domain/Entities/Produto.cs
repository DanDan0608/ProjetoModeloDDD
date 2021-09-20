using System;

namespace ProjetoModeloDDDv.Domain.Entities
{
    public class Produto
    {
        // Mapeando as entidades do Produto, note que possui até um FK de Cliente
        public int ProdutoID{ get; set; }
        public string Nome { get; set; }
        public decimal Valor{ get; set; }
        public bool Disponivel{ get; set; }
        public int ClienteId{ get; set; }
        public virtual Cliente Cliente{ get; set; }

    }
}
