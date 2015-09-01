using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpeechLib;


namespace PimsleurWords
{
    class VoiceManager
    {

        private readonly SpVoice _spVoice = new SpVoice();

        public SpVoice SpVoice
        {
            get { return _spVoice; }

        }

        private ISpeechObjectTokens _voices;
        private const SpeechVoiceSpeakFlags SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;


        public void SetVoice(VoiceItem voiceItem)
        {
            SpVoice.Voice = voiceItem.Voice; 
        }


        public IEnumerable<VoiceItem> GetVoices()
        {
            if (_voices == null)
            {
                _voices = SpVoice.GetVoices();
            }

            return from ISpeechObjectToken voice in _voices select new VoiceItem((SpObjectToken) voice);
        }


        public void SpeakToWav(string text, string filename, int rate, int volume = 100)
        {
            const SpeechStreamFileMode spFileMode = SpeechStreamFileMode.SSFMCreateForWrite;
            var spFileStream = new SpFileStream();
            spFileStream.Open(filename, spFileMode, false);

            SpVoice.AudioOutputStream = spFileStream;
            SpVoice.Rate = rate;
            SpVoice.Speak(text, SpFlags);
            SpVoice.WaitUntilDone(Timeout.Infinite);

            spFileStream.Close();
        }

        public void Speak(string text)
        {
            SpVoice.Speak(text, SpFlags);
        }
        

    }
}
