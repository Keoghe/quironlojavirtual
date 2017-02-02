using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Digite a descrição do produto")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Digite o valor")]
        [Range(0.10, double.MaxValue, ErrorMessage = "Valor Inválido")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite a categoria do produto")]
        public string Categoria { get; set; }
        
        public byte[] Imagem { get; set; }
        
        public string ImagemMimeType { get; set; }
    }
}
