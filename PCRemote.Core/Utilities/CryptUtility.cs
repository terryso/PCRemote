//-------------------------------------------------------------------
//��Ȩ���У���Ȩ����(C) 2006��Microsoft(China) Co.,LTD
//ϵͳ���ƣ�GMCC-ADC
//�ļ����ƣ�
//ģ�����ƣ�
//ģ���ţ�
//�������ߣ�
//������ڣ�
//����˵����
//-----------------------------------------------------------------

using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace PCRemote.Core.Utilities
{
    /// <summary>
    /// ������   ��CryptUtility
    /// ��˵��   ���ӽ����㷨
    /// ����     ��
    /// ������� ��
    /// </summary>
    public static class CryptUtility
    {
        /// <summary>
        /// EC��¼��Կ�ַ���
        /// </summary>
        public static string ECLOGIN_PASSWORD_SECRET = "ECLOGIN_PASSWORD_SECRET";

		/// <summary>
		/// ���ɻ��TOKEN��Կ�ַ���
		/// </summary>
		public static string MIX_TOKEN_SECRET = "MIX_TOKEN_SECRET";

        /// <summary>
        /// SI��Ʒ�汾�����ʺ�������Կ
        /// </summary>
        public static string SIPRODUCTEDITION_SECRET = "SIPRODUCTEDITION_SECRET";

        /// <summary>
        /// ����˵���������ܷ���
        /// ����    ���� 
        /// ������ڡ���
        /// </summary>
        /// <param name="content">��Ҫ���ܵ���������</param>
        /// <param name="secret">������Կ</param>
        /// <returns>���ؼ��ܺ������ַ���</returns>
        public static string Encrypt(string content, string secret)
        {
            if ((content == null) || (secret == null) || (content.Length == 0) || (secret.Length == 0))
                throw new ArgumentNullException("Invalid Argument");

            byte[] Key = GetKey(secret);
            byte[] ContentByte = Encoding.Unicode.GetBytes(content);
            var MSTicket = new MemoryStream();

            MSTicket.Write(ContentByte, 0, ContentByte.Length);

            byte[] ContentCryptByte = Crypt(MSTicket.ToArray(), Key);

            string ContentCryptStr = Encoding.ASCII.GetString(Base64Encode(ContentCryptByte));

            return ContentCryptStr;            
        }

        /// <summary>
        /// ����˵���������ܷ���
        /// ����    ���� 
        /// ������ڡ���
        /// </summary>
        /// <param name="content">��Ҫ���ܵ���������</param>
        /// <param name="secret">������Կ</param>
        /// <returns>���ؽ��ܺ������ַ���</returns>
        public static string Decrypt(string content, string secret)
        {
            if ((content == null) || (secret == null) || (content.Length == 0) || (secret.Length == 0))
                throw new ArgumentNullException("Invalid Argument");

            byte[] Key = GetKey(secret);

            byte[] CryByte = Base64Decode(Encoding.ASCII.GetBytes(content));
            byte[] DecByte = Decrypt(CryByte, Key);

            byte[] RealDecByte;
            string RealDecStr;
            
            RealDecByte = DecByte;
            byte[] Prefix = new byte[Constants.Operation.UnicodeReversePrefix.Length];
            Array.Copy(RealDecByte, Prefix, 2);

            if (CompareByteArrays(Constants.Operation.UnicodeReversePrefix, Prefix))
            {
                byte SwitchTemp = 0;
                for (int i = 0; i < RealDecByte.Length - 1; i = i + 2)
                {
                    SwitchTemp = RealDecByte[i];
                    RealDecByte[i] = RealDecByte[i + 1];
                    RealDecByte[i + 1] = SwitchTemp;
                }
            }

            RealDecStr = Encoding.Unicode.GetString(RealDecByte);
            return RealDecStr;
        }
    
        //ʹ��TripleDES����
        public static byte[] Crypt(byte[] source, byte[] key)
        {
            if ((source.Length == 0) || (source == null) || (key == null) || (key.Length == 0))
            {
                throw new ArgumentException("Invalid Argument");
            }

            TripleDESCryptoServiceProvider dsp = new TripleDESCryptoServiceProvider();
            dsp.Mode = CipherMode.ECB;

            ICryptoTransform des = dsp.CreateEncryptor(key, null);

            return des.TransformFinalBlock(source, 0, source.Length);            
        }

        public static byte[] Decrypt(byte[] source, byte[] key)
        {
            if ((source.Length == 0) || (source == null) || (key == null) || (key.Length == 0))
            {
                throw new ArgumentNullException("Invalid Argument");
            }

            var dsp = new TripleDESCryptoServiceProvider {Mode = CipherMode.ECB};
            var des = dsp.CreateDecryptor(key, null);     
            var ret = new byte[source.Length + 8];

            int num = des.TransformBlock(source, 0, source.Length, ret, 0);

            ret = des.TransformFinalBlock(source, 0, source.Length);
            num = ret.Length;

            var realByte = new byte[num];
            Array.Copy(ret, realByte, num);
            ret = realByte;
            return ret;
        }

        //ԭʼbase64����
        public static byte[] Base64Encode(byte[] source)
        {
            if ((source == null) || (source.Length == 0))
                throw new ArgumentException("source is not valid");

            ToBase64Transform tb64 = new ToBase64Transform();
            MemoryStream stm = new MemoryStream();
            int pos = 0;
            byte[] buff;

            while (pos + 3 < source.Length)
            {
                buff = tb64.TransformFinalBlock(source, pos, 3);
                stm.Write(buff, 0, buff.Length);
                pos += 3;
            }

            buff = tb64.TransformFinalBlock(source, pos, source.Length - pos);
            stm.Write(buff, 0, buff.Length);

            return stm.ToArray();

        }

        //ԭʼbase64����
        public static byte[] Base64Decode(byte[] source)
        {
            if ((source == null) || (source.Length == 0))
                throw new ArgumentException("source is not valid");

            FromBase64Transform fb64 = new FromBase64Transform();
            MemoryStream stm = new MemoryStream();
            int pos = 0;
            byte[] buff;

            while (pos + 4 < source.Length)
            {
                buff = fb64.TransformFinalBlock(source, pos, 4);
                stm.Write(buff, 0, buff.Length);
                pos += 4;
            }

            buff = fb64.TransformFinalBlock(source, pos, source.Length - pos);
            stm.Write(buff, 0, buff.Length);
            return stm.ToArray();

        }

        public static byte[] GetKey(string secret)
        {
            if ((secret == null) || (secret.Length == 0))
                throw new ArgumentException("Secret is not valid");

            byte[] temp;

            ASCIIEncoding ae = new ASCIIEncoding();
            temp = Hash(ae.GetBytes(secret));

            byte[] ret = new byte[Constants.Operation.KeySize];

            int i;

            if (temp.Length < Constants.Operation.KeySize)
            {
                System.Array.Copy(temp, 0, ret, 0, temp.Length);
                for (i = temp.Length; i < Constants.Operation.KeySize; i++)
                {
                    ret[i] = 0;
                }
            }
            else
                System.Array.Copy(temp, 0, ret, 0, Constants.Operation.KeySize);

            return ret;
        }

        //�Ƚ�����byte�����Ƿ���ͬ
        public static bool CompareByteArrays(byte[] source, byte[] dest)
        {
            if ((source == null) || (dest == null))
                throw new ArgumentException("source or dest is not valid");

            bool ret = true;

            if (source.Length != dest.Length)
                return false;
            else
                if (source.Length == 0)
                    return true;

            for (int i = 0; i < source.Length; i++)
                if (source[i] != dest[i])
                {
                    ret = false;
                    break;
                }
            return ret;
        }

        //ʹ��md5����ɢ��
        public static byte[] Hash(byte[] source)
        {
            if ((source == null) || (source.Length == 0))
                throw new ArgumentException("source is not valid");

            MD5 m = MD5.Create();
            return m.ComputeHash(source);
        }

        /// <summary>
        /// �Դ���������������Hash����,���벻��Ϊ����
        /// </summary>
        /// <param name="oriPassword">��Ҫ���ܵ���������</param>
        /// <returns>����Hash���ܵ�����</returns>
        public static string HashPassword(string oriPassword)
        {
            if (string.IsNullOrEmpty(oriPassword))
                throw new ArgumentException("oriPassword is valid");

            ASCIIEncoding acii = new ASCIIEncoding();
            byte[] hashedBytes = Hash(acii.GetBytes(oriPassword));

            StringBuilder sb = new StringBuilder(30);
            foreach (byte b in hashedBytes)
            {
                sb.AppendFormat("{0:X2}",b);
            }
            return sb.ToString();
        }
    }

    /// <summary>
    /// ������   ��Constants
    /// ��˵��   ���ӽ����㷨����.
    /// ����     ��
    /// ������� ��
    /// </summary>
    public class Constants
    {
        public struct Operation
        {
            public static readonly int KeySize = 24;
            public static readonly byte[] UnicodeOrderPrefix   = new byte[2] { 0xFF, 0xFE };
            public static readonly byte[] UnicodeReversePrefix = new byte[2] { 0xFE, 0xFF };
        }
    }
}
