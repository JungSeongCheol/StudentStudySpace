using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalShopApp2020.NewFolder1
{
    public enum BaseMode
    {
        NONE,   // 기본 상태
        INSERT, // 입력 상태
        UPDATE, // 수정 상태
        DELETE,
        SELECT
    }

    public class Commons
    {
        public static string USERID = string.Empty;

        public static readonly string COMNSTR = "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";

        /// <summary>
        /// MD5 암호화 메서드
        /// </summary>
        /// <param name="md5Hash">해시키값</param>
        /// <param name="input">평문</param>
        /// <returns>암호화된 문자열</returns>
        public static string GETMD5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sbuiler = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sbuiler.Append(data[i].ToString("x2"));
            }
            return sbuiler.ToString();
        }
    }
}
