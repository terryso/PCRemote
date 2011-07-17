using System;
using System.Collections.Generic;
using System.Xml;

namespace PCRemote.Core.Configuration
{
    [Serializable]
    public abstract class ConfigurationBase
    {
        protected static ConfigurationBase GetConfig(Type type, string sectionName)
        {
            var config = PCRemoteConfiguration.GetConfig();
            if (config == null)
                return null;
            var node = config.GetSection(sectionName);
            var typeConfig = GetConfig(type, node);
            return typeConfig;
        }

        protected static ConfigurationBase GetConfig(Type type, XmlNode node)
        {
            var config = Activator.CreateInstance(type) as ConfigurationBase;
            if (config != null)
            {
                config.LoadDefaultConfigurations();
                config.LoadValuesFromConfigurationXml(node);
            }

            return config;
        }

        protected virtual void LoadDefaultConfigurations()
        {
        }

        protected virtual void LoadValuesFromConfigurationXml(XmlNode node)
        {
        }

        protected static ConfigurationBase GetConfig<T>(XmlNode section)
        {
            Type thisType = typeof(T);
            return GetConfig(thisType, section);
        }

        protected static ConfigurationBase GetConfig<T>(string sectionName)
        {
            Type thisType = typeof(T);
            return GetConfig(thisType, sectionName);
        }

        #region Help

        public static string GetStringAttribute(XmlAttributeCollection attributes, string key, string defaultValue)
        {
            if (attributes[key] != null
                && !string.IsNullOrEmpty(attributes[key].Value))
                return attributes[key].Value;
            return defaultValue;
        }

        public static int GetIntAttribute(XmlAttributeCollection attributes, string key, int defaultValue)
        {
            int val = defaultValue;

            if (attributes[key] != null
                && !string.IsNullOrEmpty(attributes[key].Value))
            {
                int.TryParse(attributes[key].Value, out val);
            }
            return val;
        }

        public static bool GetBoolAttribute(XmlAttributeCollection attributes, string key, bool defaultValue)
        {
            bool val = defaultValue;

            if (attributes[key] != null
                && !string.IsNullOrEmpty(attributes[key].Value))
            {
                bool.TryParse(attributes[key].Value, out val);
            }
            return val;
        }

        protected Dictionary<string, T> LoadModules<T>(XmlNode node, ref Dictionary<string, T> modules)
        {
            if (modules == null)
            {
                modules = new Dictionary<string, T>();
            }

            if (node != null)
            {
                foreach (XmlNode n in node.ChildNodes)
                {
                    if (n.NodeType != XmlNodeType.Comment)
                    {
                        switch (n.Name)
                        {
                            case "clear":
                                modules.Clear();
                                break;
                            case "remove":
                                XmlAttribute removeNameAtt = n.Attributes["name"];
                                string removeName = removeNameAtt == null ? null : removeNameAtt.Value;

                                if (!string.IsNullOrEmpty(removeName) && modules.ContainsKey(removeName))
                                {
                                    modules.Remove(removeName);
                                }

                                break;
                            case "add":

                                XmlAttribute en = n.Attributes["enabled"];
                                if (en != null && en.Value == "false")
                                    continue;

                                XmlAttribute nameAtt = n.Attributes["name"];
                                XmlAttribute typeAtt = n.Attributes["type"];
                                string name = nameAtt == null ? null : nameAtt.Value;
                                string itype = typeAtt == null ? null : typeAtt.Value;

                                if (string.IsNullOrEmpty(name))
                                {
                                    continue;
                                }

                                if (string.IsNullOrEmpty(itype))
                                {
                                    continue;
                                }

                                Type type = Type.GetType(itype);

                                if (type == null)
                                {
                                    continue;
                                }

                                T mod = default(T);

                                try
                                {
                                    mod = (T)Activator.CreateInstance(type);
                                }
                                catch (Exception ex)
                                {
                                    //ExceptionLogger.Log(ex);
                                }

                                if (mod == null)
                                {
                                    continue;
                                }

                                modules[name] = mod;
                                break;
                        }
                    }
                }
            }
            return modules;
        }

        #endregion
    }
}