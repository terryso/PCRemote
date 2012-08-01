using PCRemote.Core.Entities;

namespace PCRemote.Core.Contracts
{
    public interface IWeiboService
    {
        /// <summary>
        /// ����һ��΢��
        /// </summary>
        /// <param name="weibo">΢������</param>
        void SendWeibo(string weibo);

        /// <summary>
        /// �Ƴ�һ��΢��
        /// </summary>
        /// <param name="weiboId">΢��Id</param>
        void RemoveWeibo(string weiboId);

        /// <summary>
        /// ����һ����ͼƬ��΢��
        /// </summary>
        /// <param name="weibo">΢������</param>
        /// <param name="pic">ͼƬ���ص�ַ</param>
        void SendWeiboWithPicture(string weibo, string pic);

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="weiboId">΢��Id</param>
        /// <param name="comment">��������</param>
        void SendComment(string weiboId, string comment);

        /// <summary>
        /// ��ȡ��ǰ��¼�û��ĵ�һ��΢��
        /// </summary>
        /// <returns></returns>
        Weibo GetMyFirstWeibo();

        /// <summary>
        /// ��֤��ǰ��¼�û�
        /// </summary>
        /// <returns></returns>
        WeiboUser VerifyCredentials();
    }
}