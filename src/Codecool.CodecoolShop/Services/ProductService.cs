using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services {
    public class ProductService {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        private readonly ISupplierDao supplierDao;
        

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao) {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierDao = supplierDao;
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
            => productDao.GetByCategoryId(categoryId);

        public IProductDao Dao() => productDao;
        public IEnumerable<Product> GetProductsForSupplier(int supplierId)
            => productDao.GetBySupplierId(supplierId);
        public Supplier GetProductSupplier(int supplierId) => supplierDao.Get(supplierId);
        public ProductCategory GetProductCategory(int categoryId) => productCategoryDao.Get(categoryId);
        public Product Get(int id) => productDao.Get(id);
    }
}
