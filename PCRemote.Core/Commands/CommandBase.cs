using System;
using PCRemote.Core.Entities;

namespace PCRemote.Core.Commands
{
    public class CommandBase
    {
        protected void SendComment(CommandContext context, string message)
        {
            var weiboService = context.WeiboService;
            var weiboId = context.WeiboId;
            try
            {
                if (weiboService is SinaWeiboService)
                    weiboService.SendComment(weiboId, message + "有问题请@四眼蒙面侠 " + DateTime.Now.Ticks);
                else if (weiboService is QQWeiboService)
                    weiboService.SendComment(weiboId, message + "有问题请@suchuanyi " + DateTime.Now.Ticks);
            }
            catch (Exception)
            {
                //todo: 记录错误日志
            }
        }
    }
}