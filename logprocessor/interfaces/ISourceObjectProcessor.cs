namespace logprocessor.interfaces
{
    public interface ISourceObjectProcessor
    {
        IEvaluatedObject Process(IDataSourceObject dataSourceObject);
    }
}
