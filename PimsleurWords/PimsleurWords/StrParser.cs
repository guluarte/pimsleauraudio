using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PimsleurWords
{
    class StrParser
    {
        private static readonly Regex Unit = new Regex(
   @"(?<sequence>\d+)\r\n(?<start>\d{2}\:\d{2}\:\d{2},\d{3}) --\> " +
   @"(?<end>\d{2}\:\d{2}\:\d{2},\d{3})\r\n(?<text>[\s\S]*?\r\n\r\n)",
   RegexOptions.Compiled | RegexOptions.ECMAScript); 
        
        
        private readonly string _file;

        List<SubtitleLine> _subtitleLines = new List<SubtitleLine>();

        public List<SubtitleLine> SubtitleLines
        {
            get { return _subtitleLines; }
            private set { _subtitleLines = value; }
        }

        public StrParser(string file)
        {
            this._file = file;
            Parser();
        }

        private void Parser()
        {
            string subtitleText = File.ReadAllText(this._file);

            MatchCollection subtitles = Unit.Matches(subtitleText);

            foreach (Match subtitle in subtitles)
            {
                short sequence = Convert.ToInt16(subtitle.Groups["sequence"].Value);
                var starTimeSpan = TimeSpan.Parse(subtitle.Groups["start"].Value.Replace(",", "."));
                var endTimeSpan = TimeSpan.Parse(subtitle.Groups["end"].Value.Replace(",", "."));
                string text = subtitle.Groups["text"].Value;
                
                var subtitleLine = new SubtitleLine(sequence, starTimeSpan, endTimeSpan, text);
                _subtitleLines.Add(subtitleLine);

            }


        }
    }
}
