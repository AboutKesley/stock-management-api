using Stock.Domain.Interfaces;
using Stock.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Domain.Services
{
    internal class ItemService : IItemService
    {
        public IItemRepository _itemRepository { get; set; }

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Item CreateItem(Item item)
        {
            return _itemRepository.CreateItem(item);
        }
    }
}
