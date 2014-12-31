namespace Game.DnDInsider
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Xml.Linq;

    public class ExpandoObjectHelper
    {
        private static List<string> KnownLists;
        public static void Parse(dynamic parent, XElement node, List<string> knownLists = null)
        {
            if (knownLists != null)
            {
                KnownLists = knownLists;
            }
            IEnumerable<XElement> sorted = from XElement elt in node.Elements() orderby node.Elements(elt.Name.LocalName).Count() descending select elt;

            if (node.HasElements)
            {
                int nodeCount = node.Elements(sorted.First().Name.LocalName).Count();
                bool foundNode = false;
                if (KnownLists != null && KnownLists.Count > 0)
                {
                    foundNode = (from XElement el in node.Elements() where KnownLists.Contains(el.Name.LocalName) select el).Any();
                }

                if (nodeCount > 1 || foundNode == true)
                {
                    // At least one of the child elements is a list
                    var item = new ExpandoObject();
                    List<dynamic> list = null;
                    string elementName = string.Empty;
                    foreach (var element in sorted)
                    {
                        if (element.Name.LocalName != elementName)
                        {
                            list = new List<dynamic>();
                            elementName = element.Name.LocalName;
                        }

                        if (element.HasElements ||
                            (KnownLists != null && KnownLists.Contains(element.Name.LocalName)))
                        {
                            Parse(list, element);
                            AddProperty(item, element.Name.LocalName, list);
                        }
                        else
                        {
                            Parse(item, element);
                        }
                    }

                    foreach (var attribute in node.Attributes())
                    {
                        AddProperty(item, attribute.Name.ToString(), attribute.Value.Trim());
                    }

                    AddProperty(parent, node.Name.ToString(), item);
                }
                else
                {
                    var item = new ExpandoObject();

                    foreach (var attribute in node.Attributes())
                    {
                        AddProperty(item, attribute.Name.ToString(), attribute.Value.Trim());
                    }

                    //element
                    foreach (var element in sorted)
                    {
                        Parse(item, element);
                    }
                    AddProperty(parent, node.Name.ToString(), item);
                }
            }
            else
            {
                if (node.HasAttributes == true)
                {
                    AddAttributeProperty(parent, node);
                }
                else
                {
                    AddProperty(parent, node.Name.ToString(), node.Value.Trim());
                }
            }
        }

        private static void AddProperty(dynamic parent, string name, object value)
        {
            if (parent is List<dynamic>)
            {
                (parent as List<dynamic>).Add(value);
            }
            else
            {
                (parent as IDictionary<string, object>)[name] = value;
            }
        }

        private static void AddAttributeProperty(dynamic parent, XElement element)
        {
            if (parent is List<dynamic>)
            {
                (parent as List<dynamic>).Add(element.Value.Trim());
            }
            else
            {
                dynamic item = new ExpandoObject();
                (item as IDictionary<string, object>)["Value"] = element.Value.Trim();
                foreach (var attribute in element.Attributes())
                {
                    (item as IDictionary<string, object>)[attribute.Name.LocalName] = attribute.Value.Trim();
                }

                if ((parent as IDictionary<string, object>).ContainsKey(element.Name.LocalName) == true)
                {
                    var list = (parent as IDictionary<string, object>)[element.Name.LocalName] as ICollection<dynamic>;
                    if (list == null)
                    {
                        item = new List<dynamic> { (parent as IDictionary<string, object>)[element.Name.LocalName], item };
                    }
                    else
                    {
                        list.Add(item);
                        item = list;
                    }
                }

                (parent as IDictionary<string, object>)[element.Name.LocalName] = item;
            }
        }
    }
}
