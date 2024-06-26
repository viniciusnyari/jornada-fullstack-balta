﻿using System.ComponentModel.DataAnnotations;

namespace Fina.Shared.Requests.Categories;

public class GetCategoryByIdRequest : Request
{
    [Required(ErrorMessage = "O identificador é obrigatório para obter a categoria")]
    public long Id { get; set; }
}