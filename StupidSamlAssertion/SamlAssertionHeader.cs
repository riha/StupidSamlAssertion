using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Xml;

namespace StupidSamlAssertionBehaviour
{
    class SamlAssertionHeader : MessageHeader
    {
        private readonly SamlAssertion _assertion;

        public SamlAssertionHeader(X509Certificate2 cert)
        {
            _assertion = new SamlAssertion
            {
                AssertionId = "_13d16f22e77e12c5b589f9c54a621a27",
                Issuer = "https://federation.apotekensservice.se"
            };

            var samlSubject = new SamlSubject { Name = "My Subject" };

            var samlAttribute = new SamlAttribute { Namespace = "http://richardhallgren.com" };
            samlAttribute.AttributeValues.Add("Some Value 1");
            samlAttribute.Name = "My Attribute Value";

            var samlAttributeStatement = new SamlAttributeStatement();
            samlAttributeStatement.Attributes.Add(samlAttribute);
            samlAttributeStatement.SamlSubject = samlSubject;

            _assertion.Statements.Add(samlAttributeStatement);

            _assertion.SigningCredentials = new X509SigningCredentials(cert);
            _assertion.SigningToken = new X509SecurityToken(cert);

            _assertion.SigningCredentials = new X509SigningCredentials(cert, new SecurityKeyIdentifier((new X509SecurityToken(cert)).CreateKeyIdentifierClause<X509RawDataKeyIdentifierClause>()));
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            var secTokenSerializer = new WSSecurityTokenSerializer();

            var samlToken = new SamlSecurityToken(_assertion);

            secTokenSerializer.WriteToken(writer, samlToken);
        }

        public override string Name
        {
            get { return (_assertion.AssertionId); }
        }

        public override string Namespace
        {
            get { return "urn:oasis:names:tc:SAML:2.0:assertion"; }
        }
    }
}
