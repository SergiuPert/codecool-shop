using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos
{
    public interface IOrderDao : IDao<Order>
    {
        void AddItem(Order item,Product product);
        void RemoveItem(Order item,Product product);
        decimal GetTotal(Order item);
    }
}
