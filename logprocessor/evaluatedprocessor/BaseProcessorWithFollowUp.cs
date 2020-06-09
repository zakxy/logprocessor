using logprocessor.interfaces;

namespace logprocessor.evaluatedprocessor
{
    public class BaseProcessorWithFollowUp 
    {
        protected IEvaluatedObjectProcessor _followUpProcessor;

        protected BaseProcessorWithFollowUp(IEvaluatedObjectProcessor followUpProcessor = null)
        {
            _followUpProcessor = followUpProcessor;
        }
    }
}
