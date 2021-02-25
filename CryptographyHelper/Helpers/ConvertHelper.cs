using System;
using System.Collections.Generic;
using System.Text;

namespace CryptographyHelper.Helpers {
    internal class ConvertHelper {
        public static string ArrayBytesToString(byte[] conteudo) {
            string[] arrayHex = Array.ConvertAll(conteudo, b => b.ToString("X2"));
            return string.Concat(arrayHex);
        }

        public static byte[] StringToArrayBytes(string conteudo) {
            int qtdeBytesEncriptados = conteudo.Length / 2;
            byte[] arrayConteudoEncriptado = new byte[qtdeBytesEncriptados];

            for (int i = 0; i < qtdeBytesEncriptados; i++) {
                arrayConteudoEncriptado[i] = Convert.ToByte(conteudo.Substring(i * 2, 2), 16);
            }

            return arrayConteudoEncriptado;
        }
    }
}
