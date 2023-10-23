using MyStrore.Data;

namespace MyStrore.Services
{
    public interface IProductsServices
    {
       
        Task<IEnumerable<Products>> GetAllAsynsc();
       Task<Products> GetById(string id);
        Task CreateAsync(Products product);

        Task UpdateAsync(string id, Products products);
        Task DeleteAysnc(string id);
    }
}
