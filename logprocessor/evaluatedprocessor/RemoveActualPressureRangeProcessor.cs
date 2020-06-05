using logprocessor.data.models;
using logprocessor.interfaces;

namespace logprocessor.evaluatedprocessor
{
    public class RemoveActualPressureRangeProcessor : IEvaluatedObjectProcessor
    {
        private double _minRange;
        private double _maxRange;
        private IEvaluatedObjectProcessor _followUpProcessor;

        public RemoveActualPressureRangeProcessor(double minRange, double maxRange, IEvaluatedObjectProcessor followUpProcessor = null)
        {
            _minRange = minRange;
            _maxRange = maxRange;
            _followUpProcessor = followUpProcessor;
        }

        public void Process(IEvaluatedObject evaluatedObject)
        {
            ProductionLogEvaluated evaluatedLogObject = evaluatedObject as ProductionLogEvaluated;

            evaluatedLogObject.MomentValueObjects.RemoveAll(x => x.ActualPressure >= _minRange && x.ActualPressure <= _maxRange);

            _followUpProcessor?.Process(evaluatedLogObject);
        }
    }
}
