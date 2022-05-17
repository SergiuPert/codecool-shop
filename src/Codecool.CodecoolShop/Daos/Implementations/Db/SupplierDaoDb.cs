using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations {
	public class SupplierDaoDb:ISupplierDao {
		private readonly AppDbContext _appDbContext;
		public SupplierDaoDb(AppDbContext appDbContext) => _appDbContext = appDbContext;
		public void Add(Supplier item) {
			_appDbContext.Suppliers.Add(item);
			_appDbContext.SaveChanges();
		}

		public Supplier Get(int id) => _appDbContext.Suppliers.Find(id);

		public IEnumerable<Supplier> GetAll() => _appDbContext.Suppliers;

		public void Remove(int id) {
			_appDbContext.Suppliers.Remove(_appDbContext.Suppliers.Find(id));
			_appDbContext.SaveChanges();
		}
	}
}
