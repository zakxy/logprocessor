using logprocessor.data.models;
using System.Data;

namespace logprocessor
{
    public class CreateDataTableProcessor
    {
        public DataTable Process(ProductionLogEvaluated evaluatedObject)
        {
            DataTable table = new DataTable();
            CreateColumns(table);
            CreateRows(table, evaluatedObject);
            return table;
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
