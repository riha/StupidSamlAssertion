using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace StupidSamlAssertionBehaviour
{
    public class StupidSamlAssertionInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState) { }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var samlAssertionHeader = new SamlAssertionHeader(new CertFinder().FindCert());

            request.Headers.Add(samlAssertionHeader);

            return null;
        }
    }
}
