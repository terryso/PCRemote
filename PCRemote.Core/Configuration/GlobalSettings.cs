namespace PCRemote.Core.Configuration
{
    /// <summary>
    /// 提供给插件的全局设置
    /// </summary>
    public class GlobalSettings
    {
        private static readonly GlobalSettings Settings;

        static GlobalSettings()
        {
            Settings = new GlobalSettings();
        }

        /// <summary>
        /// 缓存
        /// </summary>
        public int CacheSizeMb { get; set; }

        /// <summary>
        /// 速度限制
        /// </summary>
        public int SpeedLimit { get; set; }

        /// <summary>
        /// 取得全局设置
        /// </summary>
        /// <returns></returns>
        public static GlobalSettings GetSettings()
        {
            return Settings;
        }
    }
}