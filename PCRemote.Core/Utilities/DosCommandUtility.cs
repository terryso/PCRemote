using System.Diagnostics;

namespace PCRemote.Core.Utilities
{
    public class DosCommandUtility
    {
        public static string RunCmd(string command)
        {
            //实例一个Process类，启动一个独立进程
            //Process类有一个StartInfo属性，这个是ProcessStartInfo类，包括了一些属性和方法，下面我们用到了他的几个属性：
            var p = new Process
                        {
                            StartInfo =
                                {
                                    FileName = "cmd.exe",
                                    Arguments = "/c " + command,
                                    UseShellExecute = false,
                                    RedirectStandardInput = true,
                                    RedirectStandardOutput = true,
                                    RedirectStandardError = true,
                                    CreateNoWindow = true
                                }
                        };
            p.Start();   //启动
            p.StandardInput.WriteLine("exit");        //不过要记得加上Exit要不然下一行程式执行的时候会当机
            return p.StandardOutput.ReadToEnd();      //从输出流取得命令执行结果
        }
    }
}