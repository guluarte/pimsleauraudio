namespace PimsleurWords
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openTSVFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseOriginal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubtitleFileOriginal = new System.Windows.Forms.TextBox();
            this.cbVoice = new System.Windows.Forms.ComboBox();
            this.cbVoice2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.voiceRate1 = new System.Windows.Forms.NumericUpDown();
            this.voiceRate2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.voiceItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.voiceItemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceRate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceRate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceItemBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // openTSVFileDialog
            // 
            this.openTSVFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.voiceRate2);
            this.groupBox1.Controls.Add(this.voiceRate1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbVoice2);
            this.groupBox1.Controls.Add(this.btnGenerate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBrowseOriginal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSubtitleFileOriginal);
            this.groupBox1.Controls.Add(this.cbVoice);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generator";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(493, 117);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(105, 23);
            this.btnGenerate.TabIndex = 35;
            this.btnGenerate.Text = "Generate Files";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Origin:";
            // 
            // btnBrowseOriginal
            // 
            this.btnBrowseOriginal.Location = new System.Drawing.Point(523, 14);
            this.btnBrowseOriginal.Name = "btnBrowseOriginal";
            this.btnBrowseOriginal.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOriginal.TabIndex = 31;
            this.btnBrowseOriginal.Text = "Browse";
            this.btnBrowseOriginal.UseVisualStyleBackColor = true;
            this.btnBrowseOriginal.Click += new System.EventHandler(this.btnBrowseOriginal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Subtitle File Original Language:";
            // 
            // txtSubtitleFileOriginal
            // 
            this.txtSubtitleFileOriginal.Location = new System.Drawing.Point(160, 16);
            this.txtSubtitleFileOriginal.Name = "txtSubtitleFileOriginal";
            this.txtSubtitleFileOriginal.Size = new System.Drawing.Size(357, 20);
            this.txtSubtitleFileOriginal.TabIndex = 27;
            // 
            // cbVoice
            // 
            this.cbVoice.AllowDrop = true;
            this.cbVoice.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVoice.FormattingEnabled = true;
            this.cbVoice.Location = new System.Drawing.Point(159, 42);
            this.cbVoice.Name = "cbVoice";
            this.cbVoice.Size = new System.Drawing.Size(135, 21);
            this.cbVoice.Sorted = true;
            this.cbVoice.TabIndex = 25;
            // 
            // cbVoice2
            // 
            this.cbVoice2.AllowDrop = true;
            this.cbVoice2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbVoice2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVoice2.FormattingEnabled = true;
            this.cbVoice2.Location = new System.Drawing.Point(160, 71);
            this.cbVoice2.Name = "cbVoice2";
            this.cbVoice2.Size = new System.Drawing.Size(135, 21);
            this.cbVoice2.Sorted = true;
            this.cbVoice2.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Target:";
            // 
            // voiceRate1
            // 
            this.voiceRate1.Location = new System.Drawing.Point(381, 45);
            this.voiceRate1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.voiceRate1.Name = "voiceRate1";
            this.voiceRate1.Size = new System.Drawing.Size(120, 20);
            this.voiceRate1.TabIndex = 40;
            // 
            // voiceRate2
            // 
            this.voiceRate2.Location = new System.Drawing.Point(381, 67);
            this.voiceRate2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.voiceRate2.Name = "voiceRate2";
            this.voiceRate2.Size = new System.Drawing.Size(120, 20);
            this.voiceRate2.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Rate:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Rate:";
            // 
            // voiceItemBindingSource
            // 
            this.voiceItemBindingSource.DataSource = typeof(PimsleurWords.VoiceItem);
            // 
            // voiceItemBindingSource1
            // 
            this.voiceItemBindingSource1.DataSource = typeof(PimsleurWords.VoiceItem);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 188);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Pimsleur Words";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceRate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceRate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceItemBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource voiceItemBindingSource;
        private System.Windows.Forms.BindingSource voiceItemBindingSource1;
        private System.Windows.Forms.OpenFileDialog openTSVFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubtitleFileOriginal;
        private System.Windows.Forms.ComboBox cbVoice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbVoice2;
        private System.Windows.Forms.NumericUpDown voiceRate1;
        private System.Windows.Forms.NumericUpDown voiceRate2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}

