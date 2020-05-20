using System.Collections.Generic;

namespace logprocessor.data.models
{
    public class ProductionLogEvaluated 
    {
        public string Designation { get; set; }
        public List<ProductionLogEvaluatedMomentValues> MomentValueObjects { get; set; }

        public ProductionLogEvaluated()
        {
            MomentValueObjects = new List<ProductionLogEvaluatedMomentValues>();
        }
    }
}
