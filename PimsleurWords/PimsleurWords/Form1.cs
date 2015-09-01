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
            string[] wavSeparators = Directory.GetFiles(@".\sounds_separators", "*.wav", SearchOption.TopDirectoryOnly);

            CleanDir();

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
            var rand = new Random();
            for (int i = 0; i < fragments.Count + 5; i++)
            {

                if (i < fragments.Count)
                {
                    j++;
                    File.Copy(wavSeparators[rand.Next(wavSeparators.Length)], string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    j++;
                    File.Copy(".\\sounds_separators\\space_short.wav", string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));
                    
                    voiceManager.SetVoice(fragments[i].Voice2);
                    j++;
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));
                    voiceManager.SpeakToWav(fragments[i].TextTrasnlated, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate2.Value);

                    voiceManager.SetVoice(fragments[i].Voice1);

                    j++;
                    File.Copy(".\\sounds_separators\\space_short.wav", string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    j++;
                    voiceManager.SpeakToWav(fragments[i].TextTarget, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate1.Value);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    j++;
                    File.Copy(".\\sounds_separators\\space_short.wav", string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));
                }
                
                int prev = i - 5;
                if (prev > 0 && prev < fragments.Count)
                {
                    j++;
                    File.Copy(wavSeparators[rand.Next(wavSeparators.Length)], string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    j++;
                    File.Copy(".\\sounds_separators\\space_short.wav", string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    voiceManager.SetVoice(fragments[prev].Voice2);

                    j++;
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    voiceManager.SpeakToWav(fragments[prev].TextTrasnlated, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate2.Value);

                    voiceManager.SetVoice(fragments[prev].Voice1);

                    j++;
                    File.Copy(".\\sounds_separators\\space_short.wav", string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    j++;
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));
                    voiceManager.SpeakToWav(fragments[prev].TextTarget, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate1.Value);


                    j++;
                    File.Copy(".\\sounds_separators\\space_short.wav", string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));
                }

                prev = prev - 5;
                if (prev > 0 && prev < fragments.Count)
                {
                    j++;
                    File.Copy(wavSeparators[rand.Next(wavSeparators.Length)], string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    j++;
                    File.Copy(".\\sounds_separators\\space_short.wav", string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    j++;
                    voiceManager.SetVoice(fragments[prev].Voice2);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));
                    voiceManager.SpeakToWav(fragments[prev].TextTrasnlated, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate2.Value);

                    

                    j++;
                    File.Copy(".\\sounds_separators\\space_short.wav", string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));

                    j++;
                    voiceManager.SetVoice(fragments[prev].Voice1);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));
                    voiceManager.SpeakToWav(fragments[prev].TextTarget, string.Format("output_{0}.wav", j.ToString("D4")), (int)voiceRate1.Value);


                    j++;
                    File.Copy(".\\sounds_separators\\space_short.wav", string.Format("output_{0}.wav", j.ToString("D4")), true);
                    wavFiles.Add(string.Format("output_{0}.wav", j.ToString("D6")));
                }

                Application.DoEvents();

            }

            Concatenate("res.mp3", wavFiles);

            CleanDir();

            MessageBox.Show("Done");
        }

        private static void CleanDir()
        {
            string[] mp3files = Directory.GetFiles(@"./", "*.mp3", SearchOption.TopDirectoryOnly);

            foreach (var mp3File in mp3files)
            {
                File.Delete(mp3File);
            }

            string[] wavFiles = Directory.GetFiles(@"./", "*.wav", SearchOption.TopDirectoryOnly);

            foreach (var wavFile in wavFiles)
            {
                File.Delete(wavFile);
            }
        }

        public static void Concatenate(string outputFile, IEnumerable<string> sourceFiles)
        {
            //convert all files to mp3
            foreach (var sourceFile in sourceFiles)
            {
                var cmd = string.Format(" -y -i {0} -f mp3 -ab 128 -ar 44100 -ac 2 {1}", sourceFile,
                    sourceFile.Replace(".wav", ".mp3"));
                var process = Process.Start("ffmpeg.exe", cmd);
                process.WaitForExit();
            }

            var command = "/C copy /b /Y *.mp3 ";
            foreach (var sourceFile in sourceFiles)
            {
                //command += sourceFile.Replace(".wav", ".mp3")+"+";
            }

            //command = command.Trim('+');

            command += " " + outputFile;

            var processEnd = Process.Start("cmd.exe", command);
            processEnd.WaitForExit();

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
