using Stock.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Stock.Domain.Interfaces;
using Stock.Infrastructure.Database.Context;

namespace Stock.Infrastructure.Database
{
    public class ItemRepository : IItemRepository
    {  
        private readonly StockDbContext _context;

        public ItemRepository(StockDbContext context)
        {
            _context = context;
        }

        public Item Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Item? GetById(int id)
        {
            return _context.Items.Find(id);
        }  

        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public bool Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return false;
            _context.Items.Remove(item);
            _context.SaveChanges();
            return true;
        }

        public Item? Update(int id, Item item)
        {
           var existingItem = _context.Items.FirstOrDefault(x => x.Id == id);
            if (existingItem == null)
                return null;

            existingItem.Update(item.Name, item.Quantity, item.Type, item.Price);
            _context.SaveChanges();
            return existingItem;
        }

    }
}
