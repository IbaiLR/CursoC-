using System.ComponentModel.DataAnnotations;

namespace EfLearning.ViewModels;

public class ProductCreateViewModel
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Name { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
    public decimal Price { get; set; }
}
