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
			if(orderItem is not null) orderItem.amount++;
			else orderItem=new() { amount=1,ProductId=product.Id,OrderId=item.Id,Id=items.Count+1 };
			item.total+=product.DefaultPrice;
			_appDbContext.Items.Update(orderItem);
			_appDbContext.Orders.Update(item);
			_appDbContext.SaveChanges();
		}

		public void RemoveItem(Order item,Product product) {
			List<OrderItem> items = _appDbContext.Items.Where(orderItem => orderItem.OrderId==item.Id).ToList();
			OrderItem orderItem = items.FirstOrDefault(prod => prod.ProductId==product.Id);
			if(orderItem is null) return;
			orderItem.amount--;
			if(orderItem.amount==0) _appDbContext.Items.Remove(orderItem);
			item.total-=product.DefaultPrice;
			_appDbContext.Items.Update(orderItem);
			_appDbContext.Orders.Update(item);
			_appDbContext.SaveChanges();
		}

		public Order Get(int id) {
			Order order=_appDbContext.Orders.Find(id);
			order.products.AddRange(_appDbContext.Items.Where(item => item.OrderId==id).ToList());
			return order;
		}

		public IEnumerable<Order> GetAll() => _appDbContext.Orders;

		public decimal GetTotal(Order item) => item.total
	}
}
