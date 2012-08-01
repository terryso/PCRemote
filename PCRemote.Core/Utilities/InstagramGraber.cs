#region using

using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

#endregion

namespace PCRemote.Core.Utilities
{
    public class InstagramGraber
    {
        public List<string> Grab(string user, int count = 10)
        {
            bool hasNext;
            var firstPage = true;
            var nextUrl = string.Empty;

            var result = new List<string>();
            var web = new HtmlWeb();
            var countIndex = 0;
            do
            {
                if (firstPage)
                {
                    firstPage = false;
                    nextUrl = string.Format("http://web.stagram.com/n/{0}?vm=grid", user);
                }

                var doc = web.Load(nextUrl);
                var images = doc.DocumentNode.SelectNodes("//img[@src]");

                foreach (var att in images.Select(image => image.Attributes["src"].Value).Where(att => att.Contains("_6")))
                {
                    result.Add(att.Replace("_6", "_7"));
                    countIndex++;

                    if (count != 0 && countIndex >= count )
                        return result;
                }

                var nextNode = doc.DocumentNode.SelectSingleNode("//a[@rel='next']");
                if (nextNode != null)
                {
                    hasNext = true;
                    nextUrl = string.Format("http://web.stagram.com{0}&vm=grid", nextNode.Attributes["href"].Value);
                }
                else
                {
                    hasNext = false;
                }

            } while (hasNext);

            return result;
        }
    }
}