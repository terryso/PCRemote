// Type: SocialKit.LightRest.HttpUrlEncodedForm
// Assembly: SocialKit.LightRest, Version=0.2.1.0, Culture=neutral
// Assembly location: C:\WorkShop\Code\Weibo\Weibo\bin\Debug\SocialKit.LightRest.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SocialKit.LightRest
{
    public class HttpUrlEncodedForm : Collection<KeyValuePair<string, string>>, IHttpContentCreator
    {
        public HttpUrlEncodedForm();
        public HttpUrlEncodedForm(IEnumerable<KeyValuePair<string, string>> initialValues);

        #region IHttpContentCreator Members

        public byte[] CreateContent();
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; }

        #endregion

        public void Add(string name, string value);
        public HttpUrlEncodedForm Append(string name, string value);
    }
}
