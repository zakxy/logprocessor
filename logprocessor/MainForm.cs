using System;
using System.Data;
using System.Windows.Forms;

namespace logprocessor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView.DataSource = new LogFileProcessor().RunProcess(openFileDialog.FileName);
            }
        }
    }
}
