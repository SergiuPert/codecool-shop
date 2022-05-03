using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models {
    public class Order : BaseModel {
        public int userId { get; set; }
        public Dictionary<int,int> products { get; set; }

        public Order(int user) {
            userId= user;
            products=new();
        }
    }
}
