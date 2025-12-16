using EfLearning.ViewModels;

namespace EfLearning.Services;

public interface IProductService
{
    void Create(ProductCreateViewModel vm);
    IEnumerable<ProductListItemViewModel> GetAll();
}
