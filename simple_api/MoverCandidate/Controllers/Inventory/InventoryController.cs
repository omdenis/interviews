using Microsoft.AspNetCore.Mvc;
using MoverCandidate.Domain.Inventory;
using MoverCandidate.Domain.Inventory.Entities;
using MoverCandidate.Domain.Inventory.UseCases;
using System.Collections.Generic;

namespace MoverCandidateTest.Controllers.Inventory
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryItemsRepository _repository;
        private readonly CreateInventoryItemUseCase _createInventoryItemUseCase;
        private readonly GetAllInventoryItemsUseCase _getAllInventoryItemsUseCase;
        private readonly RemoveQuantityFromItemUseCase _removeQuantityFromItemUseCase;

        public InventoryController(InventoryItemsRepository repository,
            CreateInventoryItemUseCase createInventoryItemUseCase,
            GetAllInventoryItemsUseCase getAllInventoryItemsUseCase,
            RemoveQuantityFromItemUseCase removeQuantityFromItemUseCase
            )
        {
            this._repository = repository;
            this._createInventoryItemUseCase = createInventoryItemUseCase;
            this._getAllInventoryItemsUseCase = getAllInventoryItemsUseCase;
            this._removeQuantityFromItemUseCase = removeQuantityFromItemUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {            
            var items = _getAllInventoryItemsUseCase.Exec();
            return Ok(items);
        }

        [HttpPost]
        public void Create([FromBody] InventoryItemModel requestModel)
        {
            _createInventoryItemUseCase.Exec(requestModel);
        }

        [HttpPatch]
        public void Update([FromBody] InventoryItemModel requestModel)
        {
            _removeQuantityFromItemUseCase.Exec(requestModel);
        }

    }
}
