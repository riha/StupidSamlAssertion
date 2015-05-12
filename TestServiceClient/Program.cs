using System.ServiceModel;
using StupidSamlAssertionBehaviour;
using TestServiceContract;

namespace TestServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var binding = new BasicHttpBinding();

            var address = new EndpointAddress("http://requestb.in/t6w30ot6");

            var channelFactory = new ChannelFactory<ITestService>(binding, address);

            channelFactory.Endpoint.Behaviors.Add(new StupidSamlAssertionEnpointBehaviour());

            ITestService channel = channelFactory.CreateChannel();

            var data = channel.GetData(1337);
        }
    }
}
