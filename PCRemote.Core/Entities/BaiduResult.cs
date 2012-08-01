

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PCRemote.Core.Entities
{
    [Serializable]
    [XmlRoot("result")]
    public class BaiduResult
    {
        public BaiduResult()
        {
            Links = new List<BaiduLink>();
            DLinks = new List<BaiduLink>();
        }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("url")]
        public List<BaiduLink> Links { get; set; }

        [XmlElement("durl")]
        public List<BaiduLink> DLinks { get; set; } 
    }

    [Serializable]
    public class BaiduLink
    {
        [XmlElement("encode")]
        public string Encode { get; set; }

        [XmlElement("decode")]
        public string Decode { get; set; }

        [XmlElement("type")]
        public int Type { get; set; }

        [XmlElement("lrcid")]
        public int LrcId { get; set; }

        [XmlElement("flag")]
        public int Flag { get; set; }

        [XmlIgnore]
        public string TrueDownloadUrl
        {
            get
            {
                var index = Encode.LastIndexOf("/");
                return Encode.Substring(0, index) + "/" + Decode.Trim();
            }
        }

    }
}