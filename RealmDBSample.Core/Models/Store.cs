using System.Collections.Generic;
using System.Linq;
using Realms;

namespace RealmDBSample.Core.Models
{
    public class Store : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string CompanyName { get; set; }
        [Backlink(nameof(Product.Store))]
        public IQueryable<Product> Products { get; }
    }
}