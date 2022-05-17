using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models {
    public class Order : BaseModel {
        public int userId { get; set; }
        public List<OrderItem> products { get; set; }
        public decimal total { get; set; }
        public Order(int user) {
            userId= user;
            products=new();
        }
    }
}
