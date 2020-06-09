namespace logprocessor.interfaces
{
    public interface IDataSourceObjectProcessor
    {
        IEvaluatedObject Process(IDataSourceObject dataSourceObject);
    }
}
