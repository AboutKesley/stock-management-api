using Stock.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Stock.Domain.Interfaces;

namespace Stock.Infrastructure.Database
{
    public class ItemRepository : IItemRepository
    {  
        private static List<Item> _items = new();

        public Item Create(Item item)
        {
            _items.Add(item);
            return item;
        }

        public Item? GetById(int id)
        {
            return _items.Find(x => x.Id == id);
        }  

        public List<Item> GetAll()
        {
            return _items.ToList();
        }

        public bool Delete(int id)
        {
            var item = _items.Find(x => x.Id == id);
            if (item == null)
                return false;
            return _items.Remove(item);
        }

        public Item? Update(int id, Item item)
        {
            var existingItem = _items.Find(x => x.Id == id);
            if(existingItem == null)
                return null;

            existingItem.Update(item.Name, item.Quantity, item.Type);
          
            return existingItem;
        }

    }
}
