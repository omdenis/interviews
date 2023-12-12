using Microsoft.EntityFrameworkCore;
using MoverCandidate.Domain.Inventory.Entities;
using System.Collections.Generic;

namespace MoverCandidate.Domain.Inventory.Data
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<InventoryItemModel> InventoryItems { get; set; }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }
    }
}
