using System.ComponentModel.DataAnnotations;

namespace WebApplicationMvc.Models;

public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do produto deve ter no máximo 100 caracteres.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O preço do produto é obrigatório.")]
    [Display(Name = "Preço")]
    public decimal Preco { get; set; }

    [StringLength(500, ErrorMessage = "A descrição do produto deve ter no máximo 500 caracteres.")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
    [Display(Name = "Quantidade Em Estoque")]
    public int QuantidadeEmEstoque { get; set; }
}
