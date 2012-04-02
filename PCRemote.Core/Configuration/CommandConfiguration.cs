using System;
using System.Collections.Generic;
using System.Xml;
using PCRemote.Core.Contracts;

namespace PCRemote.Core.Configuration
{
    public class CommandConfiguration : ConfigurationBase
    {
        readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        public Dictionary<string, ICommand> Commands
        {
            get { return _commands; }
        }

        public static CommandConfiguration GetConfig()
        {
            return GetConfig<CommandConfiguration>("commands") as CommandConfiguration;
        }

        protected override void LoadValuesFromConfigurationXml(XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.NodeType != XmlNodeType.Comment)
                {
                    switch (child.Name)
                    {
                        case "clear":
                            _commands.Clear();
                            break;
                        case "remove":
                            var removeNameAtt = child.Attributes["name"];
                            var removeName = removeNameAtt == null ? null : removeNameAtt.Value;
                            if (!string.IsNullOrEmpty(removeName) && _commands.ContainsKey(removeName))
                            {
                                _commands.Remove(removeName);
                            }
                            break;
                        case "add":
                            var en = child.Attributes["enabled"];
                            if (en != null && en.Value == "false")
                                continue;

                            var nameAtt = child.Attributes["name"];
                            var chineseNameAtt = child.Attributes["chineseName"];
                            var typeAtt = child.Attributes["type"];

                            var name = nameAtt == null ? null : nameAtt.Value;
                            var chineseName = chineseNameAtt == null ? null : chineseNameAtt.Value;
                            var itype = typeAtt == null ? null : typeAtt.Value;

                            if (string.IsNullOrEmpty(name))
                                continue;

                            if (string.IsNullOrEmpty(chineseName))
                                continue;

                            if (string.IsNullOrEmpty(itype))
                                continue;

                            var type = Type.GetType(itype);
                            if (type == null)
                                continue;

                            var command = default(ICommand);

                            try
                            {
                                command = (ICommand) Activator.CreateInstance(type);
                            }
                            catch (Exception)
                            {
                            }

                            if (command == null)
                                continue;

                            var enKeys = name.Split('|');
                            var chKeys = chineseName.Split('|');

                            foreach (var enKey in enKeys)
                            {
                                _commands.Add(enKey, command);
                            }

                            foreach (var chKey in chKeys)
                            {
                                _commands.Add(chKey, command);
                            }

                            break;
                    }
                }
            }
        }
    }
}