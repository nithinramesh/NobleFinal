using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Noble.Common
{
    public static class XMLParser
    {

        public static string ReadKeyValue(string xmlPath,string key)
        {
            string retVal = string.Empty;
            XDocument doc = XDocument.Load(xmlPath);
            if (doc != null)
            {
                Dictionary<string, string> dict = doc.Descendants("Message").ToDictionary(x => x.Attribute("Id").Value,
                                                              x => x.Attribute("Text").Value);
                if (dict.Count > 0)
                {
                    if (dict.ContainsKey(key))
                    {
                        retVal = dict[key];
                    }
                    else
                    {
                        retVal = "Message not found in file.";
                    }
                }

            }
            else
            {
                retVal = "Message file not found.";
            }
            return retVal;
        }

    }
}