using PCRemote.Core.Entities;

namespace PCRemote.Core.Contracts
{
    public interface IWeiboService
    {
        /// <summary>
        /// 发送一条微博
        /// </summary>
        /// <param name="weibo">微博内容</param>
        void SendWeibo(string weibo);

        /// <summary>
        /// 发送一条带图片的微博
        /// </summary>
        /// <param name="weibo">微博内容</param>
        /// <param name="pic">图片本地地址</param>
        void SendWeiboWithPicture(string weibo, string pic);

        /// <summary>
        /// 发送一条评论
        /// </summary>
        /// <param name="weiboId">微博Id</param>
        /// <param name="comment">评论内容</param>
        void SendComment(string weiboId, string comment);

        /// <summary>
        /// 获取当前登录用户的第一条微博
        /// </summary>
        /// <returns></returns>
        Weibo GetMyFirstWeibo();

        /// <summary>
        /// 验证当前登录用户
        /// </summary>
        /// <returns></returns>
        WeiboUser VerifyCredentials();
    }
}