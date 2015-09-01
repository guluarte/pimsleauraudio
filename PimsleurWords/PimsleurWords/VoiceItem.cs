using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechLib;


namespace PimsleurWords
{
    class VoiceItem
    {
        private SpObjectToken voice;

        public SpObjectToken Voice
        {
            get { return voice; }

        }

        public VoiceItem(SpObjectToken voice)
        {
            this.voice = voice;
        }

        public override string ToString()
        {
            return voice.GetDescription();
        }
    }
}
