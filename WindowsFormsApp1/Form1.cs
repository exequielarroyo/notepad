using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Stream fileStream;
        private string fileName;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Description", "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Text = "";
            fileStream = null;
            fileName = @"C:\Users\zekie\OneDrive\Documents\Newfile.txt";
            this.Text = "New file";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Pili ka na.";
            openFileDialog.Filter = "Text Documents (*.txt)|*.txt";

            DialogResult result = openFileDialog.ShowDialog();
            Console.WriteLine(result);
            if (!openFileDialog.SafeFileName.Contains(".txt") && (result == DialogResult.OK || result== DialogResult.Cancel))
            {
                MessageBox.Show(openFileDialog.SafeFileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fileName = openFileDialog.FileName;
            fileStream = openFileDialog.OpenFile();
            StreamReader reader = new StreamReader(fileStream);
            textBox1.Text = reader.ReadToEnd();
            this.Text = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.Length - 4);
            reader.Close();
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Microsoft Sans Serif", 8.25f);
        }

        private void largerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Microsoft Sans Serif", 20);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly)
                textBox1.ReadOnly = false;
            else
                textBox1.ReadOnly = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(fileName, textBox1.Text);
            MessageBox.Show(fileName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Console.WriteLine("Save");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
