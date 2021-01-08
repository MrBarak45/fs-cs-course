using System.ServiceModel;

namespace FS_CSProject
{
    [ServiceContract(Name="")]
    public interface IConnector
    {
        [OperationContract]
        int ExecuteInsertQuery();

        [OperationContract]
        int ExecuteSelectQuery();
    }
}