using System.Collections.Generic;

namespace logprocessor.data.models
{
    public class ProductionLogDataSource
    {
        public string Designation { get; set; }
        public List<ProductionLogDataSourceMomentValues> MomentValueObjects { get; set; }

        public ProductionLogDataSource()
        {
            MomentValueObjects = new List<ProductionLogDataSourceMomentValues>();
        }
    }
}
