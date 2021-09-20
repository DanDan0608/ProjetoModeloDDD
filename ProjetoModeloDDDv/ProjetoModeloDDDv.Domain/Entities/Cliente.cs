using System;
using System.Collections.Generic;

namespace ProjetoModeloDDDv.Domain.Entities
{
    public class Cliente
    {
        // Mapeando as entidades, que estão presentes no banco
        public int CLienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome{ get; set; }
        public string Email{ get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo{ get; set; }
        public IEnumerable<Produto> Produtos { get; set; }


        public bool ClienteEspecial(Cliente Cliente) 
        {

            return Cliente.Ativo && DateTime.Now.Year - Cliente.DataCadastro.Year >= 5;
        
        }

    }
}
