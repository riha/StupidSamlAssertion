using System;
using System.ServiceModel.Configuration;

namespace StupidSamlAssertionBehaviour
{
    public class StupidSamlAssertionExtensionBehavior : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new StupidSamlAssertionEnpointBehaviour();
        }

        public override Type BehaviorType
        {
            get { return typeof(StupidSamlAssertionEnpointBehaviour); }
        }
    }

}
