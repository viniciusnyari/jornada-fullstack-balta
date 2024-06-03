using System.ComponentModel.DataAnnotations;

namespace Fina.Shared.Requests.Categories;

public class UpdateCategoryRequest : Request
{
    [Required(ErrorMessage = "O identificador é obrigatório para obter a categoria")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O título da categoria é obrigatório")]
    [MaxLength(80, ErrorMessage = "O título deve conter até 80 caracteres")]
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
}