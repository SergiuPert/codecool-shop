using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        private readonly ISupplierDao supplierCategoryDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierCategoryDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierCategoryDao = supplierCategoryDao;
        }


        public ProductCategory GetProductCategory(int categoryId)
        {
            return productCategoryDao.Get(categoryId);
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = productCategoryDao.Get(categoryId);
            return productDao.GetBy(category);
        }

        public IEnumerable<Product> GetProductsBySupplier(int supplierId=1) 
        {
            Supplier supplier = supplierCategoryDao.Get(supplierId);
            return productDao.GetBy(supplier);
        }

    }
}
