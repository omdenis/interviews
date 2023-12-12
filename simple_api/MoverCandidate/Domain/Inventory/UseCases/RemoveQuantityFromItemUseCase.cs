using MoverCandidate.Domain.Inventory.Api;
using MoverCandidate.Domain.Inventory.Entities;

namespace MoverCandidate.Domain.Inventory.UseCases
{
    public class RemoveQuantityFromItemUseCase : IUseCase
    {
        private readonly InventoryItemsRepository _repository;

        public RemoveQuantityFromItemUseCase(InventoryItemsRepository repository)
        {
            _repository = repository;
        }


        internal void Exec(InventoryItemModel item)
        {
            var existingItem = _repository.Get(item.SKU);
            if (existingItem == null)
                return;
            
            existingItem.Quantity = existingItem.Quantity - item.Quantity;
            _repository.Update(existingItem);
            
        }
    }
}
