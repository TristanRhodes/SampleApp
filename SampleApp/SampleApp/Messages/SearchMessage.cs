using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Messages
{
    public class SearchMessage
    {
        public SearchMessage(string searchTerm)
        {
            SearchTerm = searchTerm;
        }

        public string SearchTerm { get; private set; }
    }
}
