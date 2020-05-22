using System;

namespace logprocessor.data.models
{
    public class ProductionLogDataSourceMomentValues
    {
        public DateTime LogTime { get; set; }
        public double ControlPressure { get; set; }
        public double ActualPressure { get; set; }
        public double ControlTemperature { get; set; }
        public double ActualTemperature { get; set; }
    }
}
