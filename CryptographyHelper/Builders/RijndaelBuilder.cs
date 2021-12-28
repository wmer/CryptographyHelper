using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyHelper.Builders {
    internal class RijndaelBuilder {
        private readonly String key;
        private readonly String iniVector;

        public RijndaelBuilder(String key, String iniVector) {
            this.key = key;
            this.iniVector = iniVector;
        }

        public Rijndael Create() {
            Rijndael algoritmo = Rijndael.Create();
            algoritmo.Key = Encoding.ASCII.GetBytes(key);
            algoritmo.IV = Encoding.ASCII.GetBytes(iniVector);
            return algoritmo;
        }
    }
}
