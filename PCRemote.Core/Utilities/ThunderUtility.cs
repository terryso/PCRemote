using System;
using System.Runtime.InteropServices;

namespace PCRemote.Core.Utilities
{
    public class ThunderUtility
    {
        #region TaskStatus enum

        /// <summary>
        /// 任务计数
        /// </summary>
        public enum TaskStatus
        {
            TaskStatus_Connect = 0, // 已经建立连接
            TaskStatus_Download = 2, // 开始下载 
            TaskStatus_Pause = 10, // 暂停
            TaskStatus_Success = 11, // 成功下载
            TaskStatus_Fail = 12, // 下载失败
        } ;

        #endregion

        #region XL_SUCCESS enum

        public enum XL_SUCCESS
        {
            XL_SUCCESS = 0,
            XL_ERROR_FAIL = 0x10000000,

            // 尚未进行初始化
            XL_ERROR_UNINITAILIZE,

            // 不支持的协议，目前只支持HTTP
            XL_ERROR_UNSPORTED_PROTOCOL,

            // 初始化托盘图标失败
            XL_ERROR_INIT_TASK_TRAY_ICON_FAIL,

            // 添加托盘图标失败
            XL_ERROR_ADD_TASK_TRAY_ICON_FAIL,

            // 指针为空
            XL_ERROR_POINTER_IS_NULL,

            // 字符串是空串
            XL_ERROR_STRING_IS_EMPTY,

            // 传入的路径没有包含文件名
            XL_ERROR_PATH_DONT_INCLUDE_FILENAME,

            // 创建目录失败
            XL_ERROR_CREATE_DIRECTORY_FAIL,

            // 内存不足
            XL_ERROR_MEMORY_ISNT_ENOUGH,

            // 参数不合法
            XL_ERROR_INVALID_ARG,

            // 任务不存在
            XL_ERROR_TASK_DONT_EXIST,

            // 文件名不合法
            XL_ERROR_FILE_NAME_INVALID,

            // 没有实现
            XL_ERROR_NOTIMPL,

            // 已经创建的任务数达到最大任务数，无法继续创建任务
            XL_ERROR_TASKNUM_EXCEED_MAXNUM,

            // 任务类型未知
            XL_ERROR_INVALID_TASK_TYPE,

            // 文件已经存在
            XL_ERROR_FILE_ALREADY_EXIST,

            // 文件不存在
            XL_ERROR_FILE_DONT_EXIST,

            // 读取cfg文件失败
            XL_ERROR_READ_CFG_FILE_FAIL,

            // 写入cfg文件失败
            XL_ERROR_WRITE_CFG_FILE_FAIL,

            // 无法继续任务，可能是不支持断点续传，也有可能是任务已经失败
            // 通过查询任务状态，确定错误原因。
            XL_ERROR_CANNOT_CONTINUE_TASK,

            // 无法暂停任务，可能是不支持断点续传，也有可能是任务已经失败
            // 通过查询任务状态，确定错误原因。
            XL_ERROR_CANNOT_PAUSE_TASK,

            // 缓冲区太小
            XL_ERROR_BUFFER_TOO_SMALL,

            // 调用XLInitDownloadEngine的线程，在调用XLUninitDownloadEngine之前已经结束。
            // 初始化下载引擎线程，在调用XLUninitDownloadEngine之前，必须保持执行状态。
            XL_ERROR_INIT_THREAD_EXIT_TOO_EARLY,

            // TP崩溃
            XL_ERROR_TP_CRASH,

            // 任务不合法，调用XLContinueTaskFromTdFile继续任务。内部任务切换失败时，会产生这个错误。
            XL_ERROR_TASK_INVALID
        } ;

        #endregion

        static uint TaskCount;

        // 最后错误
        XL_SUCCESS LastError = XL_SUCCESS.XL_SUCCESS;

        // 当前任务标识
        int TaskId = -1;

        public ThunderUtility(string FileName, string Url, string RefUrl)
        {
            InitDownloadEngine();

            LastError = XLURLDownloadToFile(FileName, Url, RefUrl, ref TaskId);
        }

        public ThunderUtility(string TdFileFullPath)
        {
            InitDownloadEngine();

            LastError = XLContinueTaskFromTdFile(TdFileFullPath, ref TaskId);
        }

        static void InitDownloadEngine()
        {
            if (TaskCount == 0)
                if (XLInitDownloadEngine() == false)
                    return;

            TaskCount++;
        }

        static void UninitDownloadEngine()
        {
            if (TaskCount == 1)
                XLUninitDownloadEngine();

            TaskCount--;
        }

        ~ThunderUtility()
        {
            if (TaskId != -1)
                XLStopTask(TaskId);

            UninitDownloadEngine();
        }

        // GetLastError
        // 获取最后错误
        public XL_SUCCESS GetLastError()
        {
            return LastError;
        }

        // QueryTaskInfo
        // 查询当前任务信息
        public bool QueryTaskInfo(ref TaskInfo Info)
        {
            LastError = XLQueryTaskInfo(TaskId, ref Info.Status, ref Info.FileSize, ref Info.RecvSize);

            return LastError == XL_SUCCESS.XL_SUCCESS;
        }

        /// <summary>
        /// 暂停当前任务
        /// </summary>
        /// <returns></returns>
        public bool PauseTask()
        {
            LastError = XLPauseTask(TaskId, ref TaskId);

            return LastError == XL_SUCCESS.XL_SUCCESS;
        }

        /// <summary>
        /// 恢复当前任务
        /// </summary>
        /// <returns></returns>
        public bool ContinueTask()
        {
            LastError = XLContinueTask(TaskId);

            return LastError == XL_SUCCESS.XL_SUCCESS;
        }

        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <returns></returns>
        [DllImport("XLDownload.dll", EntryPoint = "XLInitDownloadEngine")]
        static extern bool XLInitDownloadEngine();

        // XLUninitDownloadEngine
        // 进行一些资源回收操作。
        [DllImport("XLDownload.dll")]
        static extern bool XLUninitDownloadEngine();

        // XLURLDownloadToFile
        // 下载指定的资源，并保存到本地文件，只支持HTTP，不支持动态链。
        [DllImport("XLDownload.dll", EntryPoint = "XLURLDownloadToFile", CharSet = CharSet.Unicode)]
        static extern XL_SUCCESS XLURLDownloadToFile(string pszFileName, string pszUrl, string pszRefUrl,
                                                     ref Int32 lTaskId);

        // XLContinueTaskFromTdFile
        // 从指定的TD文件开始新任务。
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLContinueTaskFromTdFile(string pszTdFileFullPath, ref int lTaskId);

        // XLQueryTaskInfo
        // 查询指定任务的当前状态。
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLQueryTaskInfo(int lTaskId, ref TaskStatus Status, ref UInt64 pullFileSize,
                                                 ref UInt64 pullRecvSize);

        // XLPauseTask
        // 暂停指定任务，并返回新的任务ID。
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLPauseTask(int lTaskId, ref int lNewTaskId);

        // XLContinueTask
        // 恢复已暂停的任务。
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLContinueTask(int lTaskId);

        // XLStopTask
        // 停止指定任务。
        [DllImport("XLDownload.dll")]
        static extern void XLStopTask(int lTaskId);

        // XLGetErrorMsg
        // 将错误码对应的错误消息拷贝至指定的缓冲区。
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLGetErrorMsg(XL_SUCCESS Error, string pszBuffer, ref int dwSize);

        #region Nested type: TaskInfo

        /// <summary>
        /// 任务信息
        /// </summary>
        public struct TaskInfo
        {
            public UInt64 FileSize; // 文件尺寸
            public UInt64 RecvSize; // 已下载尺寸
            public TaskStatus Status; // 状态
        } ;

        #endregion
    }
}