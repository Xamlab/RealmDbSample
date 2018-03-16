using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealmDBSample.Core.Managers.Implementation;
using RealmDBSample.Core.Models;

namespace RealmDBSample.Core.Managers
{
    public interface IDataManager
    {
        string DatabasePath { get; }
        Task Bootstrap(IProgress<string> progress);
        IEnumerable<Store> FetchAllStores();
        IEnumerable<Product> FetchAllProducts();
        IEnumerable<Product> FetchAllProducts(Store store, int skip = 0, int take = 200);
        Product FetchProductById(string id);
        IEnumerable<Category> FetchAllCategories();

        void SaveProduct(Product product, string name, double price, Category category);
        void DeleteProduct(Product product);
        Task<bool> LogInAsync(string username, string password, bool createUser = false);
    }
}