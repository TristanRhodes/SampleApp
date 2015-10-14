using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Data;
using SampleApp.Properties;
using Dapper;

namespace SampleApp.Services
{
    public interface IProductsService
    {
        List<Product> GetProducts(string searchTerm);

        List<Product> GetAssociatedProducts(int parentProductId);
    }

    public class ProductsService : IProductsService
    {
        public List<Product> GetProducts(string searchTerm)
        {
            using(var connection = new SqlConnection(Settings.Default.ProductsConnection))
            {
                var parameters = new { SearchTerm = searchTerm };

                // TODO: Specific Members
                return connection
                    .Query<Product>("SELECT Product.* FROM Product WHERE Name LIKE '%' + @SearchTerm + '%' OR Description LIKE '%' + @SearchTerm + '%' ORDER BY Name", parameters)
                    .ToList();
            }
        }

        public List<Product> GetAssociatedProducts(int parentProductId)
        {
            using (var connection = new SqlConnection(Settings.Default.ProductsConnection))
            {
                var parameters = new { ParentProductId = parentProductId };

                // TODO: Specific Members
                return connection
                    .Query<Product>("SELECT P.* FROM Product AS P INNER JOIN ProductBundle AS PB ON P.ProductId = PB.ChildProductId WHERE PB.ParentProductId = @ParentProductId ORDER BY Name", parameters)
                    .ToList();
            }
        }
    }
}
