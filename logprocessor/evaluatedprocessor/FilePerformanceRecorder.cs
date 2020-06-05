using logprocessor.interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace logprocessor.evaluatedprocessor
{
    public class FilePerformanceRecorder : IEvaluatedObjectProcessor
    {
        private string _fileName;
        private IEvaluatedObjectProcessor _followUpProcessor;

        public FilePerformanceRecorder(string fileName, IEvaluatedObjectProcessor followUpProcessor)
        {
            _fileName = fileName;
            _followUpProcessor = followUpProcessor;
        }

        public void Process(IEvaluatedObject evaluatedObject)
        {
            Stopwatch sw = Stopwatch.StartNew();

            _followUpProcessor.Process(evaluatedObject);

            var elapsed = sw.Elapsed;
            File.AppendAllText(_fileName, elapsed.TotalMilliseconds + "ms" + Environment.NewLine);
        }
    }
}
