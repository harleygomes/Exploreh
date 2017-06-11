using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exploreh.Model.Crypt
{
    public static class Crypt
    {
        public static string DecryptMD5(this string value)
        {
            byte[] keyArray;

            byte[] toEncryptArray = Convert.FromBase64String(value);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();

            string key = (string)settingsReader.GetValue("SecurityKey",
                typeof(String));

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();


            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;

            tdes.Mode = CipherMode.ECB;

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string ToSHA256(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                SHA256Managed sha256Managed = new SHA256Managed();
                UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

                byte[] hash, bytes = unicodeEncoding.GetBytes(value);
                hash = sha256Managed.ComputeHash(bytes);

                string hex = "";

                foreach (byte b in hash)
                {
                    hex += string.Format("{0:x2}", b);
                }

                return hex.ToUpper();
            }
            else
            {
                return null;
            }
        }

        public static string Base64Encode(string value)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(value);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string value)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(value);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string GerarSenha(int tamanho)
        {
            const string senhaCaracteresValidos = "abcdefghijklmnopqrstuvwxyz1234567890@#!?";

            var valormaximo = senhaCaracteresValidos.Length;
            var random = new Random(DateTime.Now.Millisecond);
            var senha = "";
            for (var indice = 0; indice < tamanho; indice++)
                senha += senhaCaracteresValidos[random.Next(0, valormaximo)];
            return senha;
        }
    }
}
