using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos
{
    public interface IProductDao : IDao<Product>
    {
        IEnumerable<Product> GetBySupplierId(int supplier);
        IEnumerable<Product> GetByCategoryId(int productCategory);
    }
}
