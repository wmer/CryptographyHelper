using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptographyHelper.Helpers {
    public class CriptographyHelper {
        private static Random random = new Random();
        public static string GetRandomKey() {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 16)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
