using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimsleurWords
{
    class AudioFragment
    {
        public string Text { get; set; }

        public string Lang { get; set; }

        public int Rate { get; set; }

        public string TextTarget { get; set; }

        public string TextTrasnlated { get; set; }

        public VoiceItem Voice1 { get; set; }

        public VoiceItem Voice2 { get; set; }
    }
}
