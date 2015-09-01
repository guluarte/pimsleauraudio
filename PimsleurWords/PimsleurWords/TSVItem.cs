using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimsleurWords
{
    class TSVItem
    {
        private string[] values;

        public String[] Values
        {
            get { return values; }
            
        }

        public TSVItem(string[] values)
        {
            this.values = values;
        }


    }
}
