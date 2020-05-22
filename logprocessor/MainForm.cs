using logprocessor.evaluatedprocessor;
using logprocessor.sourcegetter;
using logprocessor.sourceprocessor;
using System;
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
                var dataTableProcessor = new CreateDataTableProcessor();

                var processor = new LogFileProcessor(
                    sourceObjectsGetter: new CsvProductionLogFileParser(openFileDialog.FileName),
                    sourceObjectProcessor: new CsvProductionLogSortByActualPressureProcessor(),
                    evaluatedObjectProcessor: dataTableProcessor);

                processor.RunProcess();
                dataGridView.DataSource = dataTableProcessor.Result;
            }
        }
    }
}
