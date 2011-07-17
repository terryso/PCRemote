#region

using System;
using System.Configuration;
using System.Xml;

#endregion

namespace PCRemote.Core.Configuration
{
    internal class PCRemoteConfigurationHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        public virtual object Create(Object parent, Object context, XmlNode node)
        {
            var config = new PCRemoteConfiguration();
            config.LoadValuesFromConfigurationXml(node);
            return config;
        }

        #endregion
    }
}