#region using

using PCRemote.Core.Entities;
using SocialKit.LightRest;

#endregion

namespace PCRemote.Core.Utilities
{
    public class BaiduMp3Graber
    {
        private readonly RestClient _client;

        public BaiduMp3Graber()
        {
            _client = new RestClient();
        }

        public BaiduResult Grab(string song, string singer)
        {
            const string searchTemplate = "http://box.zhangmen.baidu.com/x?op=12&count=1&title={0}$${1}$$$$";
            var searchUrl = string.Format(searchTemplate, song, singer);

            var request = new HttpRequestMessage("Get", searchUrl);
            var result = _client.Send(request);

            return result.ReadContentAsXmlSerializable<BaiduResult>();
        }
    }
}