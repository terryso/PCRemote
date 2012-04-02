#region

using System.Configuration;
using System.Xml;

#endregion

namespace PCRemote.Core.Configuration
{
    public class PCRemoteConfiguration
    {
        private XmlNode _root;

        public static PCRemoteConfiguration GetConfig()
        {
            return (PCRemoteConfiguration) ConfigurationManager.GetSection("pcremote");
        }

        public void LoadValuesFromConfigurationXml(XmlNode node)
        {
            _root = node;
        }

        public XmlNode GetSection(string nodePath)
        {
            return _root.SelectSingleNode(nodePath);
        }
    }
}