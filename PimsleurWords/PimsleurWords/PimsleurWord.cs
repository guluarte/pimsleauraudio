using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimsleurWords
{
    class PimsleurWord
    {
        private string targetLangWord;

        public string TargetLangWord
        {
            get { return targetLangWord; }
        }

        private string nativeLangWord;

        public string NativeLangWord
        {
            get { return nativeLangWord; }
        }

        private string nativeLangSound;

        public String NativeLangSound
        {
            get { return nativeLangSound; }
            set { nativeLangSound = value; }
        }

        private string targetLangSound;

        public String TargetLangSound
        {
            get { return targetLangSound; }
            set { targetLangSound = value; }
        }


        public PimsleurWord(string nativeLangWord, string nativeLangSound, string targetLangWord, string targetLangSound)
        {
            this.nativeLangWord = nativeLangWord;
            this.nativeLangSound = nativeLangSound;

            this.targetLangWord = targetLangWord;
            this.targetLangSound = targetLangSound;
        }


        public PimsleurWord(string nativeLangWord, string targetLangWord)
        {
            this.nativeLangWord = nativeLangWord;
            this.targetLangWord = targetLangWord;
        }

    }
}
