using System.Security.Cryptography.X509Certificates;

namespace StupidSamlAssertionBehaviour
{
    public class CertFinder
    {
        private readonly X509Store _store;

        public CertFinder()
        {
            _store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            _store.Open(OpenFlags.ReadOnly);
        }

        public X509Certificate2 FindCert()
        {
            var cert = _store.Certificates[0];

            return cert;
        }
    }
}
