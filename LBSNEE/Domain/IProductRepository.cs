namespace LBSNEE.Domain;
public interface IProductRepository
{
    void Add(Product entity);
    void Delete(Product entity);
    Task<Product?> Get(int id);
    Task<List<Product>> GetAll();
    void Update(Product entity);
}