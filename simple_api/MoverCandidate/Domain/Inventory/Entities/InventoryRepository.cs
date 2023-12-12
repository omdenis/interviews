using System;
using System.Collections.Generic;
using System.Linq;
using MoverCandidate.Domain.Inventory.Data;

namespace MoverCandidate.Domain.Inventory.Entities
{
    public class InventoryItemsRepository
    {
        public InventoryDbContext _db;

        public InventoryItemsRepository(InventoryDbContext db)
        {
            _db = db;
        }

        public void Create(InventoryItemModel item)
        {
            var newProject = _db.InventoryItems.Add(item).Entity;
            _db.SaveChanges();
        }

        public IList<InventoryItemModel> GetAll()
        {
            return _db
                .InventoryItems
                .ToList();
        }

        
        internal InventoryItemModel? Get(string sku) // TODO: string should by typed, ex: SkuType
        {
            var item = _db.InventoryItems.FirstOrDefault<InventoryItemModel>(i => i.SKU == sku);
            return item;
        }

        internal void Update(InventoryItemModel existingItem)
        {
            _db.SaveChanges();
        }
    }
}
