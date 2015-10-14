using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Data;

namespace SampleApp.Messages
{
    public class AddProductMessage
    {
        public AddProductMessage(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            Product = product;
        }

        public Product Product { get; private set; }
    }
}
