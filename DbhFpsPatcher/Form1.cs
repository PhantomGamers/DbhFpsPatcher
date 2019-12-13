using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DbhFpsPatcher
{
    public partial class Form1 : Form
    {
        private static readonly string GameExe = "DetroitBecomeHuman.exe";
        private static readonly string GameName = "Detroit Become Human";
        private static Form1 form = null;

        public Form1()
        {
            InitializeComponent();
            Version ver = Assembly.GetEntryAssembly().GetName().Version;
            this.Text = GameName + " FPS Patcher v" + ver.Major + "." + ver.Minor + (ver.Build.ToString() == "0" ? "" : "." + ver.Build.ToString());
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            form = this;
        }

        public static float GetFPSLimit()
        {
            float index = -1;
            form.StatusText.Invoke((MethodInvoker)(() => { index = (float)form.numericUpDown1.Value; }));
            return index;
        }

        public static void IncrementProgress(int value)
        {
            form.progressBar1.Invoke((MethodInvoker)(() => { form.progressBar1.Increment(value); }));
        }

        public static void SetProgress(int value, Color? color = null)
        {
            form.progressBar1.Invoke((MethodInvoker)(() => { form.progressBar1.Value = value; }));
            form.progressBar1.Invoke((MethodInvoker)(() => { form.progressBar1.ForeColor = color.GetValueOrDefault(Color.Green); }));
        }

        public static void SetStatus(string status, Color color)
        {
            form.StatusText.Invoke((MethodInvoker)(() => { form.StatusText.Text = status; }));
            form.StatusText.Invoke((MethodInvoker)(() => { form.StatusText.ForeColor = color; }));
        }

        public void CheckStatus()
        {
            if (File.Exists(this.PathBox.Text) && Path.GetFileName(this.PathBox.Text) == GameExe)
            {
                this.StatusText.Text = "Found executable!";
                this.StatusText.ForeColor = Color.YellowGreen;
                this.PatchButton.Enabled = true;
                this.progressBar1.Value = 0;
            }
            else
            {
                this.StatusText.Text = "Waiting...";
                this.StatusText.ForeColor = Color.Blue;
                this.PatchButton.Enabled = false;
                this.progressBar1.Value = 0;
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            // Show the dialog that allows user to select a file, the
            // call will result a value from the DialogResult enum
            // when the dialog is dismissed.
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = $"{GameName} | {GameExe}"
            };
            DialogResult result = dlg.ShowDialog();
            // if a file is selected
            if (result == DialogResult.OK)
            {
                // Set the selected file URL to the textbox
                this.PathBox.Text = dlg.FileName;

                // Change status
                CheckStatus();
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            this.PathBox.Text = files[0];
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && Path.GetExtension(files[0]) == ".exe" && Path.GetFileName(files[0]) == GameExe)
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void PatchButton_Click(object sender, EventArgs e)
        {
            if (!PatchWorker.IsBusy)
            {
                PatchButton.Enabled = false;
                PatchWorker.RunWorkerAsync();
            }
        }

        private void PatchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.PatchFunction(this.PathBox.Text);
            SetProgress(100);
            form.PatchButton.Invoke((MethodInvoker)(() => { form.PatchButton.Enabled = true; }));
        }

        private void PathBox_TextChanged(object sender, EventArgs e)
        {
            CheckStatus();
        }

        private void ResolutionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckStatus();
            Console.WriteLine(numericUpDown1.Value);
        }
    }
}