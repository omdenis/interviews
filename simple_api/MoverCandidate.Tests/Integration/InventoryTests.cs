using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoverCandidate.Domain.Inventory.Data;
using MoverCandidate.Domain.Inventory.Entities;
using MoverCandidateTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Api.Tests.Lib;

namespace MoverCandidate.Tests.Integration
{
    [TestClass]
    public class InventoryTests
    {
        private HttpClient _httpClient;
        private InventoryDbContext _db;

        [TestInitialize]
        public async Task Setup()
        {
            var webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var existingDbContextService = services.SingleOrDefault(descriptor => descriptor.ServiceType == typeof(InventoryDbContext));
                    if (existingDbContextService != null)
                        services.Remove(existingDbContextService);
                    services.AddDbContext<InventoryDbContext>(opt => opt.UseInMemoryDatabase("InMemory_" + Guid.NewGuid()));
                });
            });
            _httpClient = webHost.CreateClient();

            // Clean up DB
            _db = webHost.Services.CreateScope().ServiceProvider.GetRequiredService<InventoryDbContext>();
            await _db.Database.EnsureDeletedAsync();
            await _db.Database.EnsureCreatedAsync();

        }

        [TestMethod]
        public async Task Given_InventoryItem_When_GetAll()
        {
            var dto = new InventoryItemModel() { SKU = "S1", Description = "Description1", Quantity = 1 };
            
            await _httpClient.Create<InventoryItemModel>("Inventory", dto);
            var result = await _httpClient.Get<InventoryItemModel[]>("Inventory");
            var item = result.ToList()[0];

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(dto.SKU, item.SKU);
            Assert.AreEqual(dto.Description, item.Description);
            Assert.AreEqual(dto.Quantity, item.Quantity);
        }

        [TestMethod]
        public async Task Given_InventoryUnkownItem_Then_NewOne()
        {
            var dto1 = new InventoryItemModel() { SKU = "S1", Description = "Description1", Quantity = 1 };
            var dto2 = new InventoryItemModel() { SKU = "S2", Description = "Description2", Quantity = 2 };

            await _httpClient.Create<InventoryItemModel>("Inventory", dto1);
            await _httpClient.Create<InventoryItemModel>("Inventory", dto2);
            var result = await _httpClient.Get<InventoryItemModel[]>("Inventory");
            var item = result.ToList()[1];

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(dto2.SKU, item.SKU);
            Assert.AreEqual(dto2.Description, item.Description);
            Assert.AreEqual(dto2.Quantity, item.Quantity);
        }

        [TestMethod]
        public async Task Given_InventoryKnownItem_Then_AddQuantity()
        {
            var dto1 = new InventoryItemModel() { SKU = "S1", Description = "Description1", Quantity = 1 };
            var dto2 = new InventoryItemModel() { SKU = "S1", Description = "Description2", Quantity = 2 };

            await _httpClient.Create<InventoryItemModel>("Inventory", dto1);
            await _httpClient.Create<InventoryItemModel>("Inventory", dto2);
            var result = await _httpClient.Get<InventoryItemModel[]>("Inventory");
            var item = result.ToList()[0];

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(dto1.SKU, item.SKU);
            Assert.AreEqual(dto1.Description, item.Description);
            Assert.AreEqual(dto1.Quantity + dto2.Quantity, item.Quantity);
        }


        [TestMethod]
        public async Task Given_InventoryUpdateItem_Then_SubscructQuantity()
        {
            var dto1 = new InventoryItemModel() { SKU = "S1", Description = "Description1", Quantity = 1 };
            
            await _httpClient.Create("Inventory", dto1);
            await _httpClient.Update("Inventory", dto1);
            var result = await _httpClient.Get<InventoryItemModel[]>("Inventory");
            var item = result.ToList()[0];

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(dto1.SKU, item.SKU);
            Assert.AreEqual(dto1.Description, item.Description);
            Assert.AreEqual(0, item.Quantity);
        }
    }
}
