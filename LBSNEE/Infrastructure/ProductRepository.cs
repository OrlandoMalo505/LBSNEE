using LBSNEE.Domain;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;

namespace LBSNEE.Infrastructure;

public class ProductRepository(ApplicationDbContext _context) : IProductRepository
{
    public void Add(Product entity)
    {
        _context.Add(entity);
    }

    public void Delete(Product entity)
    {
        _context.Products.Remove(entity);
    }
    public async Task<Product?> Get(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products.AsNoTracking().ToListAsync();
    }

    public void Update(Product entity)
    {
        _context.Products.Update(entity);
    }

}
