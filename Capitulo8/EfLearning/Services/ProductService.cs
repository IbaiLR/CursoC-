using EfLearning.Data;
using EfLearning.Models;
using EfLearning.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EfLearning.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(ProductCreateViewModel vm)
    {
        if (vm.Price <= 0)
            throw new ArgumentException("El precio debe ser mayor que cero");

        var product = new Product
        {
            Name = vm.Name,
            Price = vm.Price,
            CreatedAt = DateTime.UtcNow
        };

        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public IEnumerable<ProductListItemViewModel> GetAll()
    {
        return _context.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Select(p => new ProductListItemViewModel
            {
                Name = p.Name,
                Price = p.Price,
                CreatedAt = p.CreatedAt
            })
            .ToList();
    }
}
