using Stock.Domain.Enums;
using Stock.Domain.Interfaces;
using Stock.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Domain.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Item Create(Item item) 
        {  
            if (string.IsNullOrWhiteSpace(item.Name))
                throw new Exception("Item name cannot be empty, null or space.");

            if (item.Quantity < 0)
                throw new Exception("Item quantity cannot be negative.");

            if (!Enum.IsDefined(typeof(ItemType),item.Type))
                throw new Exception("Invalid item type.");

            //return item;
            return _itemRepository.Create(item);
        }

        public Item? GetById (int id)
        {
            if( id <= 0)
                throw new Exception("Invalid item ID.");

            return _itemRepository.GetById(id);
        }

        public List<Item> GetAll() 
        { 
            return _itemRepository.GetAll();
        }

        public bool Delete(int id) 
        {
            if (id <= 0)
                throw new Exception("Invalid item ID.");

            return _itemRepository.Delete(id);

        }
        public Item? Update(int id, Item item) 
        {
            if (id <= 0)
                throw new Exception("Invalid item ID.");

            return _itemRepository.Update(id, item);
        }
    }
}
