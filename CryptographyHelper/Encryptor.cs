using CryptographyHelper.Builders;
using CryptographyHelper.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyHelper {
    public class Encryptor {
        public String Encrypt(String text, String key, String IniVector) {
            ICryptoTransform encryptor = CreateEncryptor(key, IniVector);

            using (MemoryStream mStream = new MemoryStream()) {
                using (CryptoStream encryp = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write)) {
                    using (StreamWriter writer = new StreamWriter(encryp)) {
                        writer.Write(text);
                    }
                }

                return ConvertHelper.ArrayBytesToString(mStream.ToArray());
            }
        }

        private ICryptoTransform CreateEncryptor(String key, String iniVector) {
            using (var algoritmo = new RijndaelBuilder(key, iniVector).Create()) {
                return algoritmo.CreateEncryptor(algoritmo.Key, algoritmo.IV);
            }
        }
    }
}
