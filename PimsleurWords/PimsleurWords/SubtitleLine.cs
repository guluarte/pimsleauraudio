using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimsleurWords
{
    class SubtitleLine
    {
        public short Number { get; set; }
        public TimeSpan BeginTimeSpan { get; set; }
        public TimeSpan EndTimeSpan { get; set; }
        public string Text { get; set; }

        public SubtitleLine(short number, TimeSpan beginTimeSpan, TimeSpan endTimeSpan, string text)
        {
            this.Number = number;
            this.BeginTimeSpan = beginTimeSpan;
            this.EndTimeSpan = endTimeSpan;
            this.Text = text;
        }


    }
}
