﻿
using MyStrore.Data;

namespace MyStrore.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Categories>> GetAllAsynsc();
        Task<Categories> GetById(string id);
        Task CreateAsync(Categories category);

        Task UpdateAsync(string id, Categories categories);
        Task DeleteAysnc(string id);

    }
}