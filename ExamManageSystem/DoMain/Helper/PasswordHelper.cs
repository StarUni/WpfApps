using System;
using System.Security.Cryptography;
using System.Text;

namespace ExamManageSystem.DoMain.Helper
{
    public static class PasswordHelper
    {
        public static char[] data = { 
            'a','c','d','e','f','h','k','m', 'n','r','s','t','w','x','y', 
            '1','2','3','4','5','6','7','8','9','0'};
        /// <summary> 
        /// MD5 加密字符串 
        /// </summary> 
        /// <param name="rawPass">源字符串</param> 
        /// <returns>加密后字符串</returns> 
        private static string MD5Encoding(string rawPass)
        {
            // 创建MD5类的默认实例：MD5CryptoServiceProvider 
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(rawPass);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder stb = new StringBuilder();
            foreach (byte b in hs)
            {
                // 以十六进制格式格式化 
                stb.Append(b.ToString("x2"));
            }
            return stb.ToString();
        }

        /// <summary>
        /// Generate salt
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GenerateSalt(int len)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = rand.Next(data.Length);
                char ch = data[index];
                sb.Append(ch);
            }
            return sb.ToString();
        }

        /// <summary> 
        /// MD5盐值加密 
        /// </summary> 
        /// <param name="rawPass">源字符串</param> 
        /// <param name="salt">盐值</param> 
        /// <returns>加密后字符串</returns> 
        public static string MD5Encoding(string rawPass, object salt)
        {
            if(salt == null) return null;
            return MD5Encoding(rawPass + "{" + salt.ToString() + "}");
        }
    }
}
