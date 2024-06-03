using System.ComponentModel.DataAnnotations;

namespace Fina.Shared.Requests.Categories;

public class CreateCategoryRequest : Request
{
    [Required(ErrorMessage = "O título da categoria é obrigatório")]
    [MaxLength(80, ErrorMessage = "O título deve conter até 80 caracteres")]
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
}