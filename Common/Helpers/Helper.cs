using Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class Helper
    {
        public static List<SeleteModel> ListSeletedTypeCalendar()
        {
            List<SeleteModel> res=new List<SeleteModel>();
            res.Add(new SeleteModel() { 
                Value="DAY",
                Name="Today"
            });
            res.Add(new SeleteModel()
            {
                Value = "WEEK",
                Name = "This Week"
            });
            res.Add(new SeleteModel()
            {
                Value = "MONTH",
                Name = "This Month"
            });
            res.Add(new SeleteModel()
            {
                Value = "YEAR",
                Name = "This Year"
            });
            res.Add(new SeleteModel()
            {
                Value = "ALL",
                Name = "ALL"
            });
            return res;
        }

        public static string EncryptString(string plainSourceStringToEncrypt, string passPhrase)
        {
            try
            {
                //Set up the encryption objects
                using (AesCryptoServiceProvider acsp = GetProvider(Encoding.Default.GetBytes(passPhrase)))
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(plainSourceStringToEncrypt);
                    ICryptoTransform ictE = acsp.CreateEncryptor();

                    //Set up stream to contain the encryption
                    MemoryStream msS = new MemoryStream();

                    //Perform the encrpytion, storing output into the stream
                    CryptoStream csS = new CryptoStream(msS, ictE, CryptoStreamMode.Write);
                    csS.Write(sourceBytes, 0, sourceBytes.Length);
                    csS.FlushFinalBlock();

                    //sourceBytes are now encrypted as an array of secure bytes
                    byte[] encryptedBytes = msS.ToArray(); //.ToArray() is important, don't mess with the buffer

                    //return the encrypted bytes as a BASE64 encoded string
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// Decrypts a BASE64 encoded string of encrypted data, returns a plain string
        /// </summary>
        /// <param name="base64StringToDecrypt">an Aes encrypted AND base64 encoded string</param>
        /// <param name="passphrase">The passphrase.</param>
        /// <returns>returns a plain string</returns>
        public static string DecryptString(string base64StringToDecrypt, string passphrase)
        {
            try
            {
                //Set up the encryption objects
                using (AesCryptoServiceProvider acsp = GetProvider(Encoding.UTF8.GetBytes(passphrase)))
                {
                    byte[] RawBytes = Convert.FromBase64String(base64StringToDecrypt);
                    ICryptoTransform ictD = acsp.CreateDecryptor();

                    //RawBytes now contains original byte array, still in Encrypted state

                    //Decrypt into stream
                    MemoryStream msD = new MemoryStream(RawBytes, 0, RawBytes.Length);
                    CryptoStream csD = new CryptoStream(msD, ictD, CryptoStreamMode.Read);
                    //csD now contains original byte array, fully decrypted

                    //return the content of msD as a regular string
                    return (new StreamReader(csD)).ReadToEnd();
                }
            }
            catch
            {
                return "";
            }
        }

        private static AesCryptoServiceProvider GetProvider(byte[] key)
        {
            AesCryptoServiceProvider result = new AesCryptoServiceProvider();
            result.BlockSize = 128;
            result.KeySize = 128;
            result.Mode = CipherMode.CBC;
            result.Padding = PaddingMode.PKCS7;

            result.GenerateIV();
            result.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            byte[] RealKey = GetKey(key, result);
            result.Key = RealKey;
            // result.IV = RealKey;
            return result;
        }

        private static byte[] GetKey(byte[] suggestedKey, SymmetricAlgorithm p)
        {
            byte[] kRaw = suggestedKey;
            List<byte> kList = new List<byte>();

            for (int i = 0; i < p.LegalKeySizes[0].MinSize; i += 8)
            {
                kList.Add(kRaw[(i / 8) % kRaw.Length]);
            }
            byte[] k = kList.ToArray();
            return k;
        }
    }
}
