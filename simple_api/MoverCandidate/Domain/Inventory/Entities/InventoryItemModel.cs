using System.ComponentModel.DataAnnotations;

namespace MoverCandidate.Domain.Inventory.Entities
{
    public class InventoryItemModel
    {
        [Key]
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
