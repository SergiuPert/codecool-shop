using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations {
	public class OrderDaoDb:IOrderDao {
		private readonly AppDbContext _appDbContext;
		public OrderDaoDb(AppDbContext appDbContext) {
			_appDbContext=appDbContext;
		}
		public void Add(Order item) {
			_appDbContext.Orders.Add(item);
			_appDbContext.SaveChanges();
		}

		public void Remove(int id) {
			Order order=_appDbContext.Orders.Find(id);
			_appDbContext.Orders.Remove(order);
			_appDbContext.SaveChanges();
		}

		public void AddItem(Order item,Product product) {
			List<OrderItem> items=_appDbContext.Items.Where(orderItem => orderItem.OrderId==item.Id).ToList();
			OrderItem orderItem = items.FirstOrDefault(prod => prod.ProductId==product.Id);
			if(orderItem is not null)
            {
				orderItem.amount++;
				_appDbContext.Items.Update(orderItem);
			}
			else
            {
				orderItem = new OrderItem { amount = 1, ProductId = product.Id, OrderId = item.Id };
				_appDbContext.Items.Add(orderItem);
			}
			item.total+=product.DefaultPrice;
			_appDbContext.Orders.Update(item);
			_appDbContext.SaveChanges();
		}

		public void RemoveItem(Order item,Product product) {
			List<OrderItem> items = _appDbContext.Items.Where(orderItem => orderItem.OrderId==item.Id).ToList();
			OrderItem orderItem = items.FirstOrDefault(prod => prod.ProductId==product.Id);
			if(orderItem is null) return;
			orderItem.amount--;
			if(orderItem.amount==0) _appDbContext.Items.Remove(orderItem);
			else _appDbContext.Items.Update(orderItem);
			item.total-=product.DefaultPrice;
			_appDbContext.Orders.Update(item);
			_appDbContext.SaveChanges();
		}

		public Order Get(int id) {
			Order order=_appDbContext.Orders.Find(id);
			var l=_appDbContext.Items.Where(item => item.OrderId==id).ToList();
		//	order.products.AddRange(l);
			return order;
		}
		public int CountCarts()
        {
			return _appDbContext.Orders.Count();
        }

		public IEnumerable<Order> GetAll() => _appDbContext.Orders;

		public int GetTotal(Order item) => item.total;
	}
}
