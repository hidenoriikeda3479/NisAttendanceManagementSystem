using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Common
{
    /// <summary>
    /// ハッシュ化ヘルパー
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// ハッシュ化
        /// </summary>
        /// <param name="txtps">パスワード</param>
        /// <returns>ハッシュ化されたパスワード</returns>
        public static string sha512(string txtps)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                // 結合した文字列をバイト配列に変換してハッシュ化
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(txtps));

                // バイト配列を16進数文字列に変換
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
