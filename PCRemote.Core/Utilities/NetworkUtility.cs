using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using PCRemote.Core.Configuration;

namespace PCRemote.Core.Utilities
{
    /// <summary>
    /// 网络相关的静态方法
    /// </summary>
    public class NetworkUtility
    {
        /// <summary>
        /// 下载视频文件
        /// </summary>
        public static bool DownloadFile(DownloadParameter para)
        {
            //用于限速的Tick
            Int32 privateTick = 0;
            //网络数据包大小 = 1KB
            var buffer = new byte[1024];
            var request = HttpWebRequest.Create(para.Url);
            var response = request.GetResponse();
            para.TotalLength = response.ContentLength; //文件长度

            #region 检查文件是否被下载过

            //如果要下载的文件存在
            if (File.Exists(para.FilePath))
            {
                var filelength = new FileInfo(para.FilePath).Length;
                //如果文件长度相同
                if (filelength == para.TotalLength)
                {
                    //返回下载成功
                    return true;
                }
            }

            #endregion

            para.DoneBytes = 0; //完成字节数
            para.LastTick = Environment.TickCount; //系统计数
            Stream st, fs; //网络流和文件流
            BufferedStream bs; //缓冲流
            int t, limitcount = 0;
            //确定缓冲长度
            if (GlobalSettings.GetSettings().CacheSizeMb > 256 || GlobalSettings.GetSettings().CacheSizeMb < 1)
                GlobalSettings.GetSettings().CacheSizeMb = 1;
            //获取下载流
            using (st = response.GetResponseStream())
            {
                //打开文件流
                using (fs = new FileStream(para.FilePath, FileMode.Create, FileAccess.Write, FileShare.Read, 8))
                {
                    //使用缓冲流
                    using (bs = new BufferedStream(fs, GlobalSettings.GetSettings().CacheSizeMb*1024))
                    {
                        //读取第一块数据
                        var osize = st.Read(buffer, 0, buffer.Length);
                        //开始循环
                        while (osize > 0)
                        {
                            #region 判断是否取消下载

                            //如果用户终止则返回false
                            if (para.IsStop)
                            {
                                //关闭流
                                bs.Close();
                                st.Close();
                                fs.Close();
                                return false;
                            }

                            #endregion

                            //增加已完成字节数
                            para.DoneBytes += osize;

                            //写文件(缓存)
                            bs.Write(buffer, 0, osize);

                            //限速
                            if (GlobalSettings.GetSettings().SpeedLimit > 0)
                            {
                                //下载计数加一count++
                                limitcount++;
                                //下载1KB
                                osize = st.Read(buffer, 0, buffer.Length);
                                //累积到limit KB后
                                if (limitcount >= GlobalSettings.GetSettings().SpeedLimit)
                                {
                                    t = Environment.TickCount - privateTick;
                                    //检查是否大于一秒
                                    if (t < 1000) //如果小于一秒则等待至一秒
                                        Thread.Sleep(1000 - t);
                                    //重置count和计时器，继续下载
                                    limitcount = 0;
                                    privateTick = Environment.TickCount;
                                }
                            }
                            else //如果不限速
                            {
                                osize = st.Read(buffer, 0, buffer.Length);
                            }
                        } //end while
                    } //end bufferedstream
                } // end filestream
            } //end netstream

            //一切顺利返回true
            return true;
        }

        /// <summary>
        /// 下载字幕文件
        /// </summary>
        public static bool DownloadSub(DownloadParameter para)
        {
            try
            {
                //网络缓存(100KB)
                var buffer = new byte[102400];
                var request = HttpWebRequest.Create(para.Url);
                var response = request.GetResponse();

                //获取下载流
                var st = response.GetResponseStream();
                if (!para.UseDeflate)
                {
                    //打开文件流
                    using (var so = new FileStream(para.FilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read, 8))
                    {
                        //读取数据
                        var osize = st.Read(buffer, 0, buffer.Length);
                        while (osize > 0)
                        {
                            //写入数据
                            so.Write(buffer, 0, osize);
                            osize = st.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
                else
                {
                    //deflate解压缩
                    var deflate = new DeflateStream(st, CompressionMode.Decompress);
                    using (var reader = new StreamReader(deflate))
                    {
                        File.WriteAllText(para.FilePath, reader.ReadToEnd());
                    }
                }
                //关闭流
                st.Close();
                //一切顺利返回true
                return true;
            }
            catch
            {
                //发生错误返回False
                return false;
            }
        }

        /// <summary>
        /// 取得网页源代码
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string GetHtmlSource2(string url, Encoding encode)
        {
            var req = HttpWebRequest.Create(url);
            var res = req.GetResponse();
            var strm = new StreamReader(res.GetResponseStream(), encode);
            var sline = strm.ReadToEnd();
            strm.Close();
            return sline;
        }

        public static string GetHtmlSource(string url, Encoding encode)
        {
            var wc = new WebClient();
            var data = wc.DownloadData(url);
            return encode.GetString(data);
        }
    }

    /// <summary>
    /// 下载参数
    /// </summary>
    public class DownloadParameter
    {
        /// <summary>
        /// 资源的网络位置
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 要创建的本地文件位置
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 资源长度
        /// </summary>
        public Int64 TotalLength { get; set; }

        /// <summary>
        /// 已完成的字节数
        /// </summary>
        public Int64 DoneBytes { get; set; }

        /// <summary>
        /// 上次Tick的数值
        /// </summary>
        public Int64 LastTick { get; set; }

        /// <summary>
        /// 是否停止下载(可以在下载过程中进行设置，用来控制下载过程的停止)
        /// </summary>
        public bool IsStop { get; set; }

        /// <summary>
        /// 下载时是否使用Deflate解压缩
        /// </summary>
        public bool UseDeflate { get; set; }
    }

    /// <summary>
    /// 其他工具
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// 无效字符过滤
        /// </summary>
        /// <param name="input">需要过滤的字符串</param>
        /// <param name="replace">替换为的字符串</param>
        /// <returns></returns>
        public static string InvalidCharacterFilter(string input, string replace)
        {
            if (replace == null)
                replace = "";

            input = Path.GetInvalidFileNameChars().Aggregate(input, (current, item) => current.Replace(item.ToString(), replace));
            return Path.GetInvalidPathChars().Aggregate(input, (current, item) => current.Replace(item.ToString(), replace));
        }
    }
}