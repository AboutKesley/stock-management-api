using Stock.Domain.Models;
using Stock.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Domain.Interfaces
{
    public interface IItemRepository
    {
        Item Create(Item item);
        Item? GetById(int id);
        List<Item> GetAll();
        bool Delete(int id);
        Item? Update(int id, Item item);
    }
}
