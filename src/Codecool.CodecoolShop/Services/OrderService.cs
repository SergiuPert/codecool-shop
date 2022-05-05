using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class OrderService {
        private readonly IOrderDao _orderDao;
        private readonly IProductDao _productDao;

        public OrderService(IProductDao productDao,IOrderDao orderDao) {
            _orderDao=orderDao;
            _productDao=productDao;
        }
        public Order GetOrder(int orderId) => _orderDao.Get(orderId);
        public void CreateOrder(int userId) {
            Order order = new(userId);
            _orderDao.Add(order);
        }
        public void RemoveOrder(int orderId) {
            _orderDao.Remove(orderId);
        }
        public void AddToOrder(int orderId,int productId) {
            Order order=_orderDao.Get(orderId);
            if(order is null) return;
            Product product=_productDao.Get(productId);
            if(product is null) return;
            _orderDao.AddItem(order,product);
        }
        public void RemoveFromOrder(int orderId,int productId) {
            Order order = _orderDao.Get(orderId);
            if(order is null) return;
            Product product=_productDao.Get(productId);
            if(product is null) return;
            _orderDao.RemoveItem(order,product);
        }
        public decimal GetTotal(int orderId) {
            Order order = _orderDao.Get(orderId);
            if(order is null) return -1;
            return _orderDao.GetTotal(order);
        }
        public List<Product> GetProducts(int orderId) {
            List<Product> products = new List<Product>();
            Order order = _orderDao.Get(orderId);
            foreach(int productId in order.products.Keys) {
                Product product = _productDao.Get(productId);
                products.Add(product);
			}
            return products;
        }
    }
}
