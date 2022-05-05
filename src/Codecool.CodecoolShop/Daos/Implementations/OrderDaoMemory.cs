using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations {
    public class OrderDaoMemory : IOrderDao {
        private List<Order> data = new();
        private static OrderDaoMemory instance = null;

        private OrderDaoMemory() {}
        public static OrderDaoMemory GetInstance() {
            if (instance == null) instance = new OrderDaoMemory();
            return instance;
        }
        public void Add(Order item) {
            item.Id = data.Count + 1;
            data.Add(item);
        }
        public void Remove(int id) => data.Remove(Get(id));
        public Order Get(int id) => data.Find(x => x.Id == id);
        public IEnumerable<Order> GetAll() => data;
        public void AddItem(Order item,Product product) {
            Order order = data.FirstOrDefault<Order>(x => x.Id==item.Id);
            if(order is not null) { 
                order.products[product.Id]=1+order.products.GetValueOrDefault<int,int>(product.Id);
                order.total+=product.DefaultPrice;
        }   }
        public void RemoveItem(Order item,Product product) {
            Order order = data.FirstOrDefault<Order>(x => x.Id==item.Id);
            if(order is not null) {
                int productId=order.products.GetValueOrDefault<int,int>(product.Id);
                if(productId>0) {
                    order.products[product.Id]=order.products.GetValueOrDefault<int,int>(product.Id)-1;
                    if(order.products[product.Id]==0) order.products.Remove(product.Id);
                    order.total-=product.DefaultPrice;
                }
            }
        }
        public decimal GetTotal(Order item) => item.total;
    }
}
