using System;
using System.Collections.Generic;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;
using SocialKit.LightRest.OAuth;
using WeiboSDK;
using WeiboSDK.Contracts;
using WeiboSDK.Entities.QQ;
using WeiboSDK.Enums;
using WeiboSDK.Extensions;
using WeiboSDK.Factories;
using WeiboSDK.Request.QQ;
using WeiboSDK.Utilities;

namespace PCRemote.Core
{
    public class QQWeiboService : IWeiboService
    {
        readonly IWeiboClient _weiboClient;

        public QQWeiboService(string accessToken, string accessTokenSecret)
        {
            if (accessToken.IsNullOrEmpty())
                throw new ArgumentException("accessToken不能为空", "accessToken");

            if (accessTokenSecret.IsNullOrEmpty())
                throw new ArgumentException("accessTokenSecret不能为空", "accessTokenSecret");

            var token = new AccessToken(ConsumerFactory.QQConsumer, accessToken, accessTokenSecret);

            _weiboClient = new WeiboClient(token, ResultFormat.json);
        }

        #region IWeiboService Members

        /// <summary>
        /// 发送一条微博
        /// </summary>
        /// <param name="weibo">微博内容</param>
        public void SendWeibo(string weibo)
        {
            var request = new QQStatusAddRequest(weibo);
            _weiboClient.Post(request);
        }

        /// <summary>
        /// 移除一条微博
        /// </summary>
        /// <param name="weiboId">微博Id</param>
        public void RemoveWeibo(string weiboId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发送一条带图片的微博
        /// </summary>
        /// <param name="weibo">微博内容</param>
        /// <param name="pic">图片本地地址</param>
        public void SendWeiboWithPicture(string weibo, string pic)
        {
            var request = new QQStatusAddWithPicRequest(weibo, pic);
            _weiboClient.Post(request);
        }

        /// <summary>
        /// 发送一条评论
        /// </summary>
        /// <param name="weiboId">微博Id</param>
        /// <param name="comment">评论内容</param>
        public void SendComment(string weiboId, string comment)
        {
            var request = new QQCommentAddRequest(weiboId, comment) {ClientIp = IPUtility.GetFirstLocalIP()};
            _weiboClient.Post(request);
        }

        /// <summary>
        /// 获取当前登录用户的第一条微博
        /// </summary>
        /// <returns></returns>
        public Weibo GetMyFirstWeibo()
        {
            var request = new QQBroadcastTimelineRequest {ReqNum = 1};
            IList<QQStatus> weibos = _weiboClient.Get(request).Statuses;
            if (weibos != null && weibos.Count > 0)
            {
                var weibo = new Weibo
                {
                    Id = weibos[0].Id,
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
            var request = new QQUserInfoRequest();
            var user = _weiboClient.Get(request).User;

            var weiboUser = new WeiboUser
            {
                Id = user.Uid,
                UserName = user.Name,
                NickName = user.Nick
            };

            return weiboUser;
        }

        #endregion
    }
}