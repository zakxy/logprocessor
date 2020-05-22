﻿using System;
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
                var processor = new LogFileProcessor(
                    parser: new CsvProductionLogFileParser(openFileDialog.FileName),
                    sortProcessor: new CsvProductionLogSortByActualPressureProcessor(),
                    createTableProcessor: new CreateDataTableProcessor());

                dataGridView.DataSource = processor.RunProcess();
            }
        }
    }
}
