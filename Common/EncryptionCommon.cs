using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 加密/解密
    /// </summary>
    public static class EncryptionCommon
    {
        /// <summary>
        /// DES 加密 注意:密钥必须为８位
        /// </summary>
        /// <param name="inputString">待加密字符串</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string DesEncrypt(string inputString, string encryptKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(inputString);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// DES 解密 注意:密钥必须为８位
        /// </summary>
        /// <param name="inputString">待解密字符串</param>
        /// <param name="decryptKey">密钥</param>
        /// <returns>解密后的字符串</returns>
        public static string DesDecrypt(string inputString, string decryptKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] inputByteArray = new Byte[inputString.Length];
            byKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(inputString);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }

        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public static string Encryption(string express)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "oa_erp_dowork";//密匙容器的名称，保持加密解密一致才能解密成功
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plaindata = Encoding.Default.GetBytes(express);//将要加密的字符串转换为字节数组
                byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
                return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public static string Decrypt(string ciphertext)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "oa_erp_dowork";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(ciphertext);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return Encoding.Default.GetString(decryptdata);
            }
        }
    }
}
