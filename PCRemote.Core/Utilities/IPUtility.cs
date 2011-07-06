using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace PCRemote.Core.Utilities
{
    public sealed class IPUtility
    {
        [DllImport("Iphlpapi.dll")]
        static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);

        [DllImport("Ws2_32.dll")]
        static extern Int32 inet_addr(string ip);

        /// <summary>
        /// 获取本机第一块网卡的IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetFirstLocalIP()
        {
            IList<string> ips = GetLocalIP();
            return ips.Count > 0 ? ips[0] : string.Empty;
        }

        /// <summary>
        /// 获取本机的IP地址
        /// </summary>
        /// <returns></returns>
        public static IList<string> GetLocalIP()
        {
            string strHostName = Dns.GetHostName(); //得到本机的主机名
            IPAddress[] ipAddresses = Dns.GetHostAddresses(strHostName); //取得本机IP

            return (from ip in ipAddresses where IsIPAddress(ip.ToString()) select ip.ToString()).ToList();
        }

        /// <summary>
        /// 获取远程主机IP地址
        /// </summary>
        /// <param name="RemoteHostName"></param>
        /// <returns></returns>
        public static IList<string> GetRemoteIP(string RemoteHostName)
        {
            IPAddress[] ipList = Dns.GetHostAddresses(RemoteHostName);

            return (from ip in ipList where IsIPAddress(ip.ToString()) select ip.ToString()).ToList();
        }

        /// <summary>
        /// 获取本机的MAC地址
        /// </summary>
        /// <returns></returns>
        public static IList<string> GetLocalMac()
        {
            var query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            return (from ManagementObject mo in queryCollection
                    where mo["IPEnabled"].ToString() == "True"
                    select mo["MacAddress"].ToString()).ToList();
        }

        /// <summary>
        /// 获取远程主机MAC地址
        /// </summary>
        /// <param name="localIP"></param>
        /// <param name="remoteIP"></param>
        /// <returns></returns>
        public static string GetRemoteMac(string localIP, string remoteIP)
        {
            Int32 ldest = inet_addr(remoteIP); //目的ip 
            Int32 lhost = inet_addr(localIP); //本地ip 

            try
            {
                var macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                return Convert.ToString(macinfo, 16);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error:{0}", err.Message);
            }
            return 0.ToString();
        }

        #region Helper

        /// <summary>
        /// 判断字符串是否为有效的IP地址
        /// </summary>
        /// <param name="ipAddress">目标字符串</param>
        /// <returns>
        /// 	<c>true</c> 如果有效; 否则, <c>false</c>.
        /// </returns>
        static bool IsIPAddress(string ipAddress)
        {
            return Regex.IsMatch(ipAddress,
                                 @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
        }

        #endregion
    }
}