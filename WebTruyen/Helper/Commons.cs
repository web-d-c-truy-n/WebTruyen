using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;

namespace WebTruyen.Helper
{
    public class Commons
    {
        // mã hóa MD5
        public static string MD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        // Chuyển object sang string
        public string ObjectToString(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        // Chuyển string sang object
        public object StringToObject(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return new BinaryFormatter().Deserialize(ms);
            }
        }

    }

    public struct vtAdmin
    {
        public const int admin = 0;
    }
    public struct vtTacGia
    {
        public const int tacGia = 0;
        public const int dichGia = 1;
    }
    public struct ttTaiKhoan
    {
        public const int binhThuong = 0;
        public const int biKhoa30p = 1;
        public const int biKhoa1h = 2;
        public const int biKhoanVV = 3;
    }

    public struct ttTruyen
    {
        public const int dangTH = 1;
        public const int hoanThanh = 2;        
    }
}