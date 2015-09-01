using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NAudio.Wave;
using SpeechLib;


namespace PimsleurWords
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            

        }

        VoiceManager voiceManager = new VoiceManager();


        private void MainForm_Load(object sender, EventArgs e)
        {
            AddSapiVoicesComboBox();
        }

        private void AddSapiVoicesComboBox()
        {
            foreach (VoiceItem voiceItem in voiceManager.GetVoices())
            {
                cbVoice.Items.Add(voiceItem);
                cbVoice2.Items.Add(voiceItem);
            }

            cbVoice.SelectedIndex = 0;
            cbVoice2.SelectedIndex = 0;
        }

        private void buttonSelectTSVFile_Click(object sender, EventArgs e)
        {
        }

        private void btnBrowseOriginal_Click(object sender, EventArgs e)
        {
            txtSubtitleFileOriginal.Text = openFile();
        }

        private string openFile()
        {
            string file = "";

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            

            return file;
        }


        private bool validateMe()
        {
            if (string.IsNullOrWhiteSpace(txtSubtitleFileOriginal.Text))
            {
                return false;
            }


            if (string.IsNullOrWhiteSpace(cbVoice.Text))
            {
                return false;
            }


            return true;
        }

        private List<AudioFragment> fragments = new List<AudioFragment>(); 
        private void btnGenerate_Click(object sender, EventArgs e)
        {


            using (StreamReader sr = new StreamReader(txtSubtitleFileOriginal.Text))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.ToLower();

                    //"et moi, je ne t’oublierai pas et je compte sur toi","and i will not forget you, and i count on you","","","","",""

                    string[] fields = Regex.Split(line, ",\"");

                    var fragment = new AudioFragment();
                    fragment.TextTarget = fields[0].Trim('"') + ".";
                    fragment.TextTrasnlated = fields[1].Trim('"') + ".";

                    fragment.Voice1 = (VoiceItem)cbVoice.SelectedItem;
                    fragment.Voice2 = (VoiceItem)cbVoice2.SelectedItem;
                    fragments.Add(fragment);

                }//while

            }//using

            var audioText = "";
            int j = 0;
            var voiceManager = new VoiceManager();
            var wavFiles = new List<string>();
            for (int i = 0; i < fragments.Count + 5; i++)
            {

                if (i < fragments.Count)
                {

                    j++;
                    voiceManager.SetVoice(fragments[i].Voice2);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D4")));
                    voiceManager.SpeakToWav(fragments[i].TextTrasnlated, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate2.Value);

                    voiceManager.SetVoice(fragments[i].Voice1);
                    j++;
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D4")));
                    voiceManager.SpeakToWav(fragments[i].TextTarget, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate1.Value);
                }
                
                int prev = i - 5;
                if (prev > 0 && prev < fragments.Count)
                {
                    j++;
                    voiceManager.SetVoice(fragments[prev].Voice2);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D4")));
                    voiceManager.SpeakToWav(fragments[prev].TextTrasnlated, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate2.Value);

                    voiceManager.SetVoice(fragments[prev].Voice1);
                    j++;
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D4")));
                    voiceManager.SpeakToWav(fragments[prev].TextTarget, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate1.Value);
                }

                prev = prev - 5;
                if (prev > 0 && prev < fragments.Count)
                {
                    j++;
                    voiceManager.SetVoice(fragments[prev].Voice2);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D4")));
                    voiceManager.SpeakToWav(fragments[prev].TextTrasnlated, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate2.Value);

                    voiceManager.SetVoice(fragments[prev].Voice1);
                    j++;
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D4")));
                    voiceManager.SpeakToWav(fragments[prev].TextTarget, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate1.Value);
                }

                Application.DoEvents();

            }

            Concatenate("res.wav", wavFiles);

            foreach (var wavFile in wavFiles)
            {
                File.Delete(wavFile);
            }

            MessageBox.Show("Done");
        }

        public static void Concatenate(string outputFile, IEnumerable<string> sourceFiles)
        {
            byte[] buffer = new byte[1024];
            WaveFileWriter waveFileWriter = null;

            try
            {
                foreach (string sourceFile in sourceFiles)
                {
                    using (WaveFileReader reader = new WaveFileReader(sourceFile))
                    {
                        if (waveFileWriter == null)
                        {
                            // first time in create new Writer
                            waveFileWriter = new WaveFileWriter(outputFile, reader.WaveFormat);
                        }
                        else
                        {
                            if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
                            {
                                throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                            }
                        }

                        int read;
                        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            waveFileWriter.WriteData(buffer, 0, read);
                        }
                    }
                }
            }
            finally
            {
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDecay_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
