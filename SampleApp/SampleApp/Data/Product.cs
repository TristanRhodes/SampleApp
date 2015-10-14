using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data
{
    public class Product
    {
        public int? ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string StockImage { get; set; }

        public DateTime UpdatedDate { get; set; }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
                return true;

            var product = obj as Product;
            if (product == null)
                return false;

            return product.ProductId == ProductId;
        }
    }
}
