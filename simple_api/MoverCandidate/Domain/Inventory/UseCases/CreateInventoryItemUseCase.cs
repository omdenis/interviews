using MoverCandidate.Domain.Inventory.Api;
using MoverCandidate.Domain.Inventory.Entities;
using System;

namespace MoverCandidate.Domain.Inventory.UseCases
{
    public class CreateInventoryItemUseCase : IUseCase
    {
        private readonly InventoryItemsRepository _repository;

        public CreateInventoryItemUseCase(InventoryItemsRepository repository)
        {
            _repository = repository;
        }

        internal void Exec(InventoryItemModel item)
        {
            var existingItem = _repository.Get(item.SKU);
            if (existingItem == null)
            {
                _repository.Create(item);
            }
            else
            {
                existingItem.Quantity = existingItem.Quantity + item.Quantity;
                _repository.Update(existingItem);
            }
        }
    }
}
