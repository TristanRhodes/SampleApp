using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SampleApp.Services;

namespace SampleApp.Tests.Services
{
    [TestFixture]
    public class ProductsServiceTests
    {
        private ProductsService _service = new ProductsService();

        [Test]
        public void ShouldGetAllProductsForAnEmptyString()
        {
            var items = _service.GetProducts(string.Empty);
            
            Assert.IsTrue(items.Count > 0);
        }

        [Test]
        public void ShouldGetProductsMatchingSearchTerm()
        {
            var searchTerm = "laptop";
            var items = _service.GetProducts(searchTerm);

            Assert.IsTrue(items.Count > 0);

            // Check all items contain laptop somewhere.
            foreach(var item in items)
            {
                bool nameMatch = item.Name.Contains(searchTerm);
                bool descriptionMatch = item.Description.Contains(searchTerm);

                Assert.IsTrue(nameMatch || descriptionMatch);
            }
        }

        [Test]
        public void ShouldGetAssociatedProducts()
        {
            var items = _service.GetAssociatedProducts(1);

            Assert.IsTrue(items.Count > 0);
        }
    }
}
