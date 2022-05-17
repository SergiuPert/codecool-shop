using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations {
	public class ProductCategoryDaoDb:IProductCategoryDao {
		private readonly AppDbContext _appDbContext;
		public ProductCategoryDaoDb(AppDbContext appDbContext) => _appDbContext=appDbContext;
		public void Add(ProductCategory item) {
			_appDbContext.ProductCategories.Add(item);
			_appDbContext.SaveChanges();
		}

		public ProductCategory Get(int id) => _appDbContext.ProductCategories.Find(id);

		public IEnumerable<ProductCategory> GetAll() => _appDbContext.ProductCategories;

		public void Remove(int id) {
			_appDbContext.ProductCategories.Remove(_appDbContext.ProductCategories.Find(id));
			_appDbContext.SaveChanges();
		}
	}
}
