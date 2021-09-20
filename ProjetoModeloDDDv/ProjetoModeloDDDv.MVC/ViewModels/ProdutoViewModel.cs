using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDDv.MVC.ViewModels
{
    public class ProdutoViewModel
    {

        // Aqui estou configurando o Produto mapeado no Domain, com suas exigencias e mensagens de erro respectivas

        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Nome { get; set; }

        // Estou definindo o tipo de uma moeda e colocando o "range" embaixo
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "99999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal Valor { get; set; }

        [DisplayName("Disponível")]
        public bool Disponivel { get; set; }
        public int ClienteID { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}