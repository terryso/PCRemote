using System.ComponentModel;

namespace PCRemote.Core.Enums
{
    /// <summary>
    ///  邮件优先级：high（高）、low(低)、normal(正常)
    /// </summary>
    public enum EmailPriorityEnum
    {
        #region///邮件优先级

        /// <summary>
        /// 高
        /// </summary>
        [Description("高")] High,
        /// <summary>
        /// 低
        /// </summary>
        [Description("低")] Low,
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")] Normal

        #endregion
    }
}