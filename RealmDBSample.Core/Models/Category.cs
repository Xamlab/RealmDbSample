using System.Linq;
using Realms;

namespace RealmDBSample.Core.Models
{
    public class Category : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        [Backlink(nameof(Product.Category))]
        public IQueryable<Product> Products { get; }   
    }
}