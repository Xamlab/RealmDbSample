using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using PubSub;
using RealmDBSample.Core.Messages;
using RealmDBSample.Core.Models;
using RealmDBSample.Core.Services;
using Realms;
using Realms.Sync;

namespace RealmDBSample.Core.Managers.Implementation
{
    public class DataManager : IDataManager
    {
        private static readonly string HostUrl = "192.168.59.128:9080";

        private static readonly Uri ServerUrl = new Uri($"realm://{HostUrl}/~/default");
        private readonly Uri _authUrl = new Uri($"http://{HostUrl}");
        private Realm _realm;

        private static readonly byte[] EncryptionKey = new byte[64] // key MUST be exactly this size
                                                        {
                                                            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                                                            0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18,
                                                            0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28,
                                                            0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38,
                                                            0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48,
                                                            0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58,
                                                            0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68,
                                                            0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78
                                                        };

        private Realm Realm
        {
            get
            {
                if(User.Current == null) throw new Exception("Log in to continue");
                return _realm ?? (_realm = Realm.GetInstance(GetConfig()));
            }
        }

        public DataManager(IAuthenticationManager authManager)
        {
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "realmdbsample.realm");       
            OnSessionStateChanged(new SessionStateChangedMessage(authManager.State));
            this.Subscribe<SessionStateChangedMessage>(OnSessionStateChanged);
        }

        public string DatabasePath { get; }

        public async Task Bootstrap(IProgress<string> progress)
        {
            if(User.Current == null) throw new Exception("Log in to continue");
            var realm = await Realm.GetInstanceAsync(GetConfig());
            var random = new Random();
            if(realm.All<Store>().Any()) return;

            await realm.WriteAsync(r =>
                                   {
                                       var categorySize = 50;
                                       var categories = Builder<Category>.CreateListOfSize(categorySize).All()
                                                                         .With(category => category.Id = Guid.NewGuid().ToString())
                                                                         .Build();
                                       int i = 0;
                                       foreach(var category in categories)
                                       {
                                           progress.Report($"Bootstrapping categories - {i}/{categorySize}");
                                           r.Add(category);
                                           i++;
                                       }

                                       var storesSize = 5;
                                       var stores = Builder<Store>.CreateListOfSize(storesSize).All()
                                                                  .With(store => store.Id = Guid.NewGuid().ToString())
                                                                  .Build();
                                       i = 0;
                                       foreach(var store in stores)
                                       {
                                           int j = 0;
                                           var products = Builder<Product>.CreateListOfSize(random.Next(5000, 10000)).All()
                                                                          .With(product => product.Id = Guid.NewGuid().ToString())
                                                                          .With(product => product.Price = random.Next(1, 10000))
                                                                          .With(product => product.Store = store)
                                                                          .Build();
                                           var productsSize = products.Count;
                                           foreach(var product in products)
                                           {
                                               progress.Report($"Bootstrapping stores - {i}/{storesSize}, products - {j}/{productsSize}");
                                               product.Category = categories[random.Next(0, categories.Count - 1)];
                                               r.Add(product);
                                               j++;
                                           }

                                           r.Add(store);
                                           i++;
                                       }
                                   });
        }

        public IEnumerable<Store> FetchAllStores()
        {
            return Realm.All<Store>();
        }

        public IEnumerable<Product> FetchAllProducts()
        {
            return Realm.All<Product>();
        }

        public IEnumerable<Product> FetchAllProducts(Store store, int skip = 0, int take = 200)
        {
            return store.Products;
        }

        public Product FetchProductById(string id)
        {
            return Realm.Find<Product>(id);
        }

        public IEnumerable<Category> FetchAllCategories()
        {
            return Realm.All<Category>();
        }

        public void SaveProduct(Product product, string name, double price, Category category)
        {
            using(var trans = Realm.BeginWrite())
            {
                product.Name = name;
                product.Price = price;
                product.Category = category;
                trans.Commit();
            }
        }

        public void DeleteProduct(Product product)
        {
            using(var trans = Realm.BeginWrite())
            {
                Realm.Remove(product);
                trans.Commit();
            }
        }

        public async Task<bool> LogInAsync(string username, string password, bool createUser = false)
        {
            User.ConfigurePersistence(UserPersistenceMode.Encrypted, EncryptionKey);
            var user = await User.LoginAsync(Credentials.UsernamePassword(username, password, createUser), _authUrl);
            return user != null;
        }

        private SyncConfiguration GetConfig()
        {
            return new SyncConfiguration(User.Current, ServerUrl)
                   {
                       SchemaVersion = 2,
                       EncryptionKey = EncryptionKey
                   };
        }

        private void OnSessionStateChanged(SessionStateChangedMessage message)
        {
            if(message.State != SessionState.LoggedIn)
            { 
                _realm?.Dispose();
                _realm = null;
            }
        }
    }
}