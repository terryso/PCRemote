using System;
using System.Runtime.InteropServices;

namespace PCRemote.Core.Utilities
{
    public class ThunderUtility
    {
        #region TaskStatus enum

        /// <summary>
        /// �������
        /// </summary>
        public enum TaskStatus
        {
            TaskStatus_Connect = 0, // �Ѿ���������
            TaskStatus_Download = 2, // ��ʼ���� 
            TaskStatus_Pause = 10, // ��ͣ
            TaskStatus_Success = 11, // �ɹ�����
            TaskStatus_Fail = 12, // ����ʧ��
        } ;

        #endregion

        #region XL_SUCCESS enum

        public enum XL_SUCCESS
        {
            XL_SUCCESS = 0,
            XL_ERROR_FAIL = 0x10000000,

            // ��δ���г�ʼ��
            XL_ERROR_UNINITAILIZE,

            // ��֧�ֵ�Э�飬Ŀǰֻ֧��HTTP
            XL_ERROR_UNSPORTED_PROTOCOL,

            // ��ʼ������ͼ��ʧ��
            XL_ERROR_INIT_TASK_TRAY_ICON_FAIL,

            // �������ͼ��ʧ��
            XL_ERROR_ADD_TASK_TRAY_ICON_FAIL,

            // ָ��Ϊ��
            XL_ERROR_POINTER_IS_NULL,

            // �ַ����ǿմ�
            XL_ERROR_STRING_IS_EMPTY,

            // �����·��û�а����ļ���
            XL_ERROR_PATH_DONT_INCLUDE_FILENAME,

            // ����Ŀ¼ʧ��
            XL_ERROR_CREATE_DIRECTORY_FAIL,

            // �ڴ治��
            XL_ERROR_MEMORY_ISNT_ENOUGH,

            // �������Ϸ�
            XL_ERROR_INVALID_ARG,

            // ���񲻴���
            XL_ERROR_TASK_DONT_EXIST,

            // �ļ������Ϸ�
            XL_ERROR_FILE_NAME_INVALID,

            // û��ʵ��
            XL_ERROR_NOTIMPL,

            // �Ѿ��������������ﵽ������������޷�������������
            XL_ERROR_TASKNUM_EXCEED_MAXNUM,

            // ��������δ֪
            XL_ERROR_INVALID_TASK_TYPE,

            // �ļ��Ѿ�����
            XL_ERROR_FILE_ALREADY_EXIST,

            // �ļ�������
            XL_ERROR_FILE_DONT_EXIST,

            // ��ȡcfg�ļ�ʧ��
            XL_ERROR_READ_CFG_FILE_FAIL,

            // д��cfg�ļ�ʧ��
            XL_ERROR_WRITE_CFG_FILE_FAIL,

            // �޷��������񣬿����ǲ�֧�ֶϵ�������Ҳ�п����������Ѿ�ʧ��
            // ͨ����ѯ����״̬��ȷ������ԭ��
            XL_ERROR_CANNOT_CONTINUE_TASK,

            // �޷���ͣ���񣬿����ǲ�֧�ֶϵ�������Ҳ�п����������Ѿ�ʧ��
            // ͨ����ѯ����״̬��ȷ������ԭ��
            XL_ERROR_CANNOT_PAUSE_TASK,

            // ������̫С
            XL_ERROR_BUFFER_TOO_SMALL,

            // ����XLInitDownloadEngine���̣߳��ڵ���XLUninitDownloadEngine֮ǰ�Ѿ�������
            // ��ʼ�����������̣߳��ڵ���XLUninitDownloadEngine֮ǰ�����뱣��ִ��״̬��
            XL_ERROR_INIT_THREAD_EXIT_TOO_EARLY,

            // TP����
            XL_ERROR_TP_CRASH,

            // ���񲻺Ϸ�������XLContinueTaskFromTdFile���������ڲ������л�ʧ��ʱ��������������
            XL_ERROR_TASK_INVALID
        } ;

        #endregion

        static uint TaskCount;

        // ������
        XL_SUCCESS LastError = XL_SUCCESS.XL_SUCCESS;

        // ��ǰ�����ʶ
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
        // ��ȡ������
        public XL_SUCCESS GetLastError()
        {
            return LastError;
        }

        // QueryTaskInfo
        // ��ѯ��ǰ������Ϣ
        public bool QueryTaskInfo(ref TaskInfo Info)
        {
            LastError = XLQueryTaskInfo(TaskId, ref Info.Status, ref Info.FileSize, ref Info.RecvSize);

            return LastError == XL_SUCCESS.XL_SUCCESS;
        }

        /// <summary>
        /// ��ͣ��ǰ����
        /// </summary>
        /// <returns></returns>
        public bool PauseTask()
        {
            LastError = XLPauseTask(TaskId, ref TaskId);

            return LastError == XL_SUCCESS.XL_SUCCESS;
        }

        /// <summary>
        /// �ָ���ǰ����
        /// </summary>
        /// <returns></returns>
        public bool ContinueTask()
        {
            LastError = XLContinueTask(TaskId);

            return LastError == XL_SUCCESS.XL_SUCCESS;
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <returns></returns>
        [DllImport("XLDownload.dll", EntryPoint = "XLInitDownloadEngine")]
        static extern bool XLInitDownloadEngine();

        // XLUninitDownloadEngine
        // ����һЩ��Դ���ղ�����
        [DllImport("XLDownload.dll")]
        static extern bool XLUninitDownloadEngine();

        // XLURLDownloadToFile
        // ����ָ������Դ�������浽�����ļ���ֻ֧��HTTP����֧�ֶ�̬����
        [DllImport("XLDownload.dll", EntryPoint = "XLURLDownloadToFile", CharSet = CharSet.Unicode)]
        static extern XL_SUCCESS XLURLDownloadToFile(string pszFileName, string pszUrl, string pszRefUrl,
                                                     ref Int32 lTaskId);

        // XLContinueTaskFromTdFile
        // ��ָ����TD�ļ���ʼ������
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLContinueTaskFromTdFile(string pszTdFileFullPath, ref int lTaskId);

        // XLQueryTaskInfo
        // ��ѯָ������ĵ�ǰ״̬��
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLQueryTaskInfo(int lTaskId, ref TaskStatus Status, ref UInt64 pullFileSize,
                                                 ref UInt64 pullRecvSize);

        // XLPauseTask
        // ��ָͣ�����񣬲������µ�����ID��
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLPauseTask(int lTaskId, ref int lNewTaskId);

        // XLContinueTask
        // �ָ�����ͣ������
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLContinueTask(int lTaskId);

        // XLStopTask
        // ָֹͣ������
        [DllImport("XLDownload.dll")]
        static extern void XLStopTask(int lTaskId);

        // XLGetErrorMsg
        // ���������Ӧ�Ĵ�����Ϣ������ָ���Ļ�������
        [DllImport("XLDownload.dll")]
        static extern XL_SUCCESS XLGetErrorMsg(XL_SUCCESS Error, string pszBuffer, ref int dwSize);

        #region Nested type: TaskInfo

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public struct TaskInfo
        {
            public UInt64 FileSize; // �ļ��ߴ�
            public UInt64 RecvSize; // �����سߴ�
            public TaskStatus Status; // ״̬
        } ;

        #endregion
    }
}