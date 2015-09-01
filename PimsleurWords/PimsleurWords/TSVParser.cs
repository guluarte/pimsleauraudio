using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PimsleurWords
{
    class TsvParser : IEnumerable<TSVItem>
    {
        private string tsvLines;
        private List<TSVItem> itemList = new List<TSVItem>(); 

        public TsvParser(string tsvLines)
        {
            this.tsvLines = tsvLines.Trim();
            Parse();
        }

        public TsvParser(string[] lines)
        {
            this.tsvLines = String.Join("\n", lines).Trim();
            Parse();
        }

        private void Parse()
        {
            string[] lines = tsvLines.Split('\n');
            foreach (var line in lines)
            {
                string[] tsvElements = line.Split('\t');
                itemList.Add(new TSVItem(tsvElements));
            }
        }


        public IEnumerator<TSVItem> GetEnumerator()
        {
            return itemList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return itemList.GetEnumerator();
        }
    }
}
