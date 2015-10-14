using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Data;

namespace SampleApp.Messages
{
    public class ProductPreviewMessage
    {
        public ProductPreviewMessage(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            Product = product;
        }

        public Product Product { get; private set; }
    }
}
