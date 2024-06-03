using System.ComponentModel.DataAnnotations;

namespace Fina.Shared.Requests.Categories;

public class DeleteCategoryRequest : Request
{
    [Required(ErrorMessage = "O identificador é obrigatório para deletar categoria")]
    public long Id { get; set; }
}