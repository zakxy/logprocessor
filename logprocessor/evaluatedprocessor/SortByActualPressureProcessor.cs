﻿using logprocessor.data.models;
using logprocessor.interfaces;

namespace logprocessor.evaluatedprocessor
{
    public class SortByActualPressureProcessor : BaseProcessorWithFollowUp, IEvaluatedObjectProcessor
    {
        public SortByActualPressureProcessor(IEvaluatedObjectProcessor followUpProcessor = null) : base(followUpProcessor)
        {
        }

        public void Process(IEvaluatedObject evaluatedObject)
        {
            ProductionLogEvaluated evaluatedLogObject = evaluatedObject as ProductionLogEvaluated;

            evaluatedLogObject.MomentValueObjects.Sort((value1, value2) => value1.ActualPressure.CompareTo(value2.ActualPressure));

            _followUpProcessor?.Process(evaluatedLogObject);
        }
    }
}
