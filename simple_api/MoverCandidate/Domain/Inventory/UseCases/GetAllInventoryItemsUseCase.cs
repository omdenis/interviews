using MoverCandidate.Domain.Inventory.Api;
using MoverCandidate.Domain.Inventory.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MoverCandidate.Domain.Inventory.UseCases
{
    public class GetAllInventoryItemsUseCase : IUseCase
    {
        private readonly InventoryItemsRepository _repository;

        public GetAllInventoryItemsUseCase(InventoryItemsRepository repository)
        {
            _repository = repository;
        }

        internal IEnumerable<InventoryItemModel> Exec()
        {
            var result = _repository.GetAll();
            return result;
        }
    }
}
