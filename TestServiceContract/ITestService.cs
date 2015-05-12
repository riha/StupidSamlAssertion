using System.ServiceModel;

namespace TestServiceContract
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string GetData(int value);
    }

}
