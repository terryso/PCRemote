#region using

using System;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using SocialKit.LightRest.OAuth;
using WeiboSDK;
using WeiboSDK.Contracts;
using WeiboSDK.Enums;
using WeiboSDK.Extensions;
using WeiboSDK.Factories;
using WeiboSDK.Request.Sina;

#endregion

namespace PCRemote.Core
{
    public class SinaWeiboService : IWeiboService
    {
        readonly IWeiboClient _weiboClient;

        public SinaWeiboService(string accessToken, string accessTokenSecret)
        {
            if (accessToken.IsNullOrEmpty())
                throw new ArgumentException("accessToken不能为空", "accessToken");

            if (accessTokenSecret.IsNullOrEmpty())
                throw new ArgumentException("accessTokenSecret不能为空", "accessTokenSecret");

            var token = new AccessToken(ConsumerFactory.SinaConsumer, accessToken, accessTokenSecret);
            _weiboClient = new WeiboClient(token, ResultFormat.json);
        }

        public SinaWeiboService(IWeiboClient weiboClient)
        {
            _weiboClient = weiboClient;
        }

        #region IWeiboService Members

        /// <summary>
        /// 发送一条微博
        /// </summary>
        /// <param name="weibo">微博内容</param>
        public void SendWeibo(string weibo)
        {
            var request = new SinaStatusUpdateRequest(weibo);
            _weiboClient.Post(request);
        }

        /// <summary>
        /// 发送一条带图片的微博
        /// </summary>
        /// <param name="weibo">微博内容</param>
        /// <param name="pic">图片本地地址</param>
        public void SendWeiboWithPicture(string weibo, string pic)
        {
            var requst = new SinaStatusUploadRequest(weibo, pic);
            _weiboClient.Post(requst);
        }

        /// <summary>
        /// 发送一条评论
        /// </summary>
        /// <param name="weiboId">微博Id</param>
        /// <param name="comment">评论内容</param>
        public void SendComment(string weiboId, string comment)
        {
            var id = Convert.ToInt64(weiboId);
            var request = new SinaCommentAddRequest(id, comment);

            _weiboClient.Post(request);
        }

        /// <summary>
        /// 获取当前登录用户的第一条微博
        /// </summary>
        /// <returns></returns>
        public Weibo GetMyFirstWeibo()
        {
            var request = new SinaUserTimelineRequest {Count = 1};
            var weibos = _weiboClient.Get(request).Statuses;

            if (weibos != null && weibos.Count > 0)
            {
                var weibo = new Weibo
                {
                    Id = weibos[0].Id.ToString(),
                    Text = weibos[0].Text
                };

                return weibo;
            }

            return null;
        }

        /// <summary>
        /// 验证当前登录用户
        /// </summary>
        /// <returns></returns>
        public WeiboUser VerifyCredentials()
        {
            var request = new SinaVerifyCredentialsRequest();
            var user = _weiboClient.Get(request).User;

            var weiboUser = new WeiboUser
            {
                Id = user.Id.ToString(),
                UserName = user.Name,
                NickName = user.ScreenName
            };

            return weiboUser;
        }

        #endregion
    }
}