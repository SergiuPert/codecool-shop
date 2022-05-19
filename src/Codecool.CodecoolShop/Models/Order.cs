using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models {
    public class Order : BaseModel {
        public string userId { get; set; }
        public List<OrderItem> products { get; set; }
        public int total { get; set; }
        public Order()
        {
            //userId = user;
            products = new();
        }
        public int Count() => products.Count;
    }
}
