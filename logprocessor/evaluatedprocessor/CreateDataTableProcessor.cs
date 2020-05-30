﻿using logprocessor.data.models;
using logprocessor.interfaces;
using System.Collections.Generic;
using System.Data;

namespace logprocessor.evaluatedprocessor
{
    public class CreateDataTableProcessor : IEvaluatedObjectProcessor
    {
        private List<DataTable> _resultList;

        public CreateDataTableProcessor(List<DataTable> resultList)
        {
            _resultList = resultList;
        }

        public void Process(IEvaluatedObject evaluatedObject)
        {
            ProductionLogEvaluated evaluatedLogObject = evaluatedObject as ProductionLogEvaluated;

            DataTable table = new DataTable(evaluatedLogObject.Designation);
            CreateColumns(table);
            CreateRows(table, evaluatedLogObject);

            _resultList.Add(table);
        }

        private void CreateColumns(DataTable table)
        {
            table.Columns.Add("LogTime", typeof(string));
            table.Columns.Add("ControlPressure", typeof(double));
            table.Columns.Add("ActualPressure", typeof(double));
            table.Columns.Add("ControlTemperature", typeof(double));
            table.Columns.Add("ActualTemperature", typeof(double));
        }
        private void CreateRows(DataTable table, ProductionLogEvaluated evaluatedLogObject)
        {
            foreach (ProductionLogEvaluatedMomentValues momentValues in evaluatedLogObject.MomentValueObjects)
            {
                table.Rows.Add(
                    momentValues.LogTime,
                    momentValues.ControlPressure,
                    momentValues.ActualPressure,
                    momentValues.ControlTemperature,
                    momentValues.ActualTemperature);
            }
        }
    }
}
