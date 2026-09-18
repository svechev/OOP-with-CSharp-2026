using System.ServiceModel;

namespace SomeSoapService.Business_Logic
{
    [ServiceContract]
    public interface ISomeService
    {

        [OperationContract]
        string GetMahiro();
    }

    public class SomeService : ISomeService
    {
        public string GetMahiro()
        {
            return "Mahiro";
        }
    }

}
