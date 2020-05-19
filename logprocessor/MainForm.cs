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
                dataGridView.DataSource = LoadFileAndCreateTable(openFileDialog.FileName);
            }
        }

        private DataTable LoadFileAndCreateTable(string fileName)
        {
            var splittedLines = new CsvProductionLogFileParser().Parse(fileName);
            var evaluatedLines = new CsvProductionLogSortByActualPressureProcessor().Process(splittedLines);
            return new CreateDataTableProcessor().Process(evaluatedLines);
        }
    }
}
