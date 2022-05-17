using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class Product : BaseModel
    {
        public string Currency { get; set; }
        public int DefaultPrice { get; set; }
        public int ProductCategoryId { get; set; }
        public int SupplierId { get; set; }

        //public void SetProductCategory(ProductCategory productCategory)
        //{
        //    ProductCategory = productCategory;
        //    ProductCategory.Products.Add(this);
        //}
    }
}
