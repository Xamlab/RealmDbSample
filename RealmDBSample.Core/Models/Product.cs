using Realms;

namespace RealmDBSample.Core.Models
{
    public class Product : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public Store Store { get; set; }
        public Category Category { get; set; }
    }
}