using CryptographyHelper.Builders;
using CryptographyHelper.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyHelper {
    public class Decryptor {
        public String Decrypt(String text, String key, String IniVector) {
            string textoDecriptografado = "";
            try {
                ICryptoTransform decryptor = CreateDecriptor(key, IniVector);

                using (MemoryStream mStream = new MemoryStream(ConvertHelper.StringToArrayBytes(text))) {
                    using (CryptoStream encryp = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read)) {
                        using (StreamReader reader = new StreamReader(encryp)) {
                            textoDecriptografado = reader.ReadToEnd();
                        }
                    }
                }
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            return textoDecriptografado;
        }

        private ICryptoTransform CreateDecriptor(String key, String iniVector) {
            using (var algoritmo = new RijndaelBuilder(key, iniVector).Create()) {
                return algoritmo.CreateDecryptor(algoritmo.Key, algoritmo.IV);
            }
        }
    }
}
