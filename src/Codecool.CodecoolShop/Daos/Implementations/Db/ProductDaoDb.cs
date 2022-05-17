using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations {
	public class ProductDaoDb:IProductDao {

        private readonly AppDbContext _appDbContext;

        public ProductDaoDb(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public void Add(Product item) {
            _appDbContext.Products.Add(item);
            _appDbContext.SaveChanges();
        }

        public void Remove(int id) {
            Product product=_appDbContext.Products.Find(id);
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
        }

        public Product Get(int id) => _appDbContext.Products.Find(id);

        public IEnumerable<Product> GetAll() => _appDbContext.Products;

        public IEnumerable<Product> GetBySupplierId(int supplierId)
            => _appDbContext.Products.Where(p => p.SupplierId==supplierId).ToList();

        public IEnumerable<Product> GetByCategoryId(int productCategoryId)
            => _appDbContext.Products.Where(p => p.ProductCategoryId==productCategoryId).ToList();
    }
}
