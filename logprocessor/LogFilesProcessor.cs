using logprocessor.interfaces;
using System.Collections.Generic;

namespace logprocessor
{
    public class LogFilesProcessor
    {
        private ISourceObjectsGetter _sourceObjectsGetter;
        private ISourceObjectProcessor _sourceObjectProcessor;
        private IEvaluatedObjectProcessor _evaluatedObjectProcessor;

        public LogFilesProcessor(ISourceObjectsGetter sourceObjectsGetter,
            ISourceObjectProcessor sourceObjectProcessor,
            IEvaluatedObjectProcessor evaluatedObjectProcessor)
        {
            _sourceObjectsGetter = sourceObjectsGetter;
            _sourceObjectProcessor = sourceObjectProcessor;
            _evaluatedObjectProcessor = evaluatedObjectProcessor;
        }
        public void RunProcess()
        {
            List<object> results = new List<object>();
            foreach (IDataSourceObject sourceObject in _sourceObjectsGetter.GetSourceObjects())
            {
                var evaluatedObject = _sourceObjectProcessor.Process(sourceObject);
                _evaluatedObjectProcessor.Process(evaluatedObject);
            }
        }
    }
}
