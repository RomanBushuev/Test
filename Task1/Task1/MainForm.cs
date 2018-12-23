using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class MainForm : Form
    {
        //поля
        private string[] _words = null;
        private string _fileOutput = null;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// читаем файл и записываем слова сразу в память
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bInputFile_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string inputFile = File.ReadAllText(openFileDialog.FileName, Encoding.GetEncoding(1251));
                if (string.IsNullOrEmpty(inputFile))
                {
                    MessageBox.Show("В файле нет слов");
                    return;
                }
                _words = inputFile.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                tbInputFile.Text = openFileDialog.FileName;
                if (_words != null && _fileOutput != null)
                    bRun.Enabled = true;
            }
        }

        /// <summary>
        /// выбираем файл для вывода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bOutputFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _fileOutput = saveFileDialog.FileName;
                tbOutput.Text = _fileOutput;
                if (_words != null && _fileOutput != null)
                    bRun.Enabled = true;
            }
        }

        /// <summary>
        /// запустить подсчет 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRun_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                foreach (var word in _words)
                {
                    if (dictionary.ContainsKey(word))
                        dictionary[word]++;
                    else
                        dictionary[word] = 1;
                }

                File.WriteAllLines(_fileOutput,
                    dictionary.Select(z => string.Format("{0}\t{1}", z.Key, z.Value)),
                    Encoding.Unicode);

                Process.Start(_fileOutput);
            }
            catch (Exception ex)
            {
                
            }
            finally
            {

            }
        }
    }
}
