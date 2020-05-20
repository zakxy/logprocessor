using logprocessor.data.models;
using System.Linq;

namespace logprocessor
{
    public class CsvProductionLogSortByActualPressureProcessor
    {
        public ProductionLogEvaluated Process(ProductionLogDataSource sourceObject)
        {
            ProductionLogEvaluated evaluatedObject = new ProductionLogEvaluated
            {
                Designation = sourceObject.Designation
            };
            evaluatedObject.MomentValueObjects = sourceObject.MomentValueObjects.Select(x => CreateEvaluated(x)).ToList();

            evaluatedObject.MomentValueObjects.Sort((value1, value2) => value1.ActualPressure.CompareTo(value2.ActualPressure));
            return evaluatedObject;
        }

        private ProductionLogEvaluatedMomentValues CreateEvaluated(ProductionLogDataSourceMomentValues sourceValues)
        {
            return new ProductionLogEvaluatedMomentValues
            {
                LogTime = sourceValues.LogTime,
                ControlPressure = sourceValues.ControlPressure,
                ActualPressure = sourceValues.ActualPressure,
                ControlTemperature = sourceValues.ControlTemperature,
                ActualTemperature = sourceValues.ControlTemperature
            };
        }
    }
}
