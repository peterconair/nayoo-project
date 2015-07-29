using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;

namespace Nayoo.Business.Security
{
    public class PasswordHelper
    {
        #region [Internal Avialable]
        class Validate
        {
            public bool IsKey { get; set; }
            public string Value { get; set; }
        }

        private static readonly byte[] IV =
            new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };
        #endregion

        #region [Public]
        public static string Encryption(string password, string cryptoKey = "")
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                    throw new Exception("Password is required");
                if (string.IsNullOrEmpty(cryptoKey))
                {
                    var result = IsValidateAppSettingKey("PASSWORD_CRYPTO_KEY");
                    if (!result.IsKey)
                        throw new Exception("Password crypto key incorrect");

                    if (string.IsNullOrEmpty(result.Value))
                        throw new Exception("Password crypto key is empty");

                    cryptoKey = result.Value;
                }

                if (!IsPaswordMinLength(password))
                    throw new Exception("Minimum Required Password Length");

                if (!IsPaswordMaxLength(password))
                    throw new Exception("Maximum Required Password Length");


                return Encrypt(password, cryptoKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Decryption(string text, string cryptoKey = "")
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                    throw new Exception("Password is required");

                if (string.IsNullOrEmpty(cryptoKey))
                {
                    var result = IsValidateAppSettingKey("PASSWORD_CRYPTO_KEY");
                    if (!result.IsKey)
                        throw new Exception("Password crypto key incorrect");

                    if (string.IsNullOrEmpty(result.Value))
                        throw new Exception("Password crypto key is empty");

                    cryptoKey = result.Value;
                }
                return Decrypt(text, cryptoKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [Internal Function]
        static string Encrypt(string password, string cryptoKey)
        {
            string result = string.Empty;
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(password);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

                des.Key = MD5.ComputeHash(ASCIIEncoding.UTF32.GetBytes(cryptoKey));
                des.IV = IV;
                result = Convert.ToBase64String(
                    des.CreateEncryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        static string Decrypt(string text, string cryptoKey)
        {
            string result = string.Empty;
            try
            {
                byte[] buffer = Convert.FromBase64String(text);

                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(ASCIIEncoding.UTF32.GetBytes(cryptoKey));
                des.IV = IV;
                result = Encoding.Default.GetString(
                    des.CreateDecryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        static bool IsPaswordMinLength(string s)
        {
            try
            {
                var m = IsValidateAppSettingKey("PASSWORD_MIN_LENGTH");
                if (!m.IsKey)
                    throw new Exception("Password min length key incorrect");

                if (string.IsNullOrEmpty(m.Value))
                    throw new Exception("Password min length is empty");

                int min;
                bool Ok = int.TryParse(m.Value, out min);
                if (!Ok)
                    throw new Exception("Password min length incorrect");

                if (s.Length < min)
                    return false;

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static bool IsPaswordMaxLength(string s)
        {
            try
            {
                var m = IsValidateAppSettingKey("PASSWORD_MAX_LENGTH");
                if (!m.IsKey)
                    throw new Exception("Password max length key incorrect");

                if (string.IsNullOrEmpty(m.Value))
                    throw new Exception("Password max length is empty");

                int max;
                bool Ok = int.TryParse(m.Value, out max);
                if (!Ok)
                    throw new Exception("Password max length incorrect");

                if (s.Length > max)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static Validate IsValidateAppSettingKey(string key)
        {

            var result = ConfigurationManager.AppSettings[key];
            if (result == null)
                return new Validate { IsKey = false, Value = string.Empty };

            return new Validate { IsKey = true, Value = result };
        }

        #endregion
    }
}
