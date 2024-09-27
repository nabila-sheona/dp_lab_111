using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02_210042111
{

    public class CaesarCipher:IEncryption
    {
        int shift = 2;
        public string Encrypt(string text)
        {
            

            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    char c = char.IsUpper(letter) ? 'A' : 'a';
                    letter = (char)(((letter + shift - c) % 26) + c);
                    buffer[i] = letter;
                }
            }
            return new string(buffer);
        }

        public string Decrypt(string cipherText)
        {

            char[] buffer = cipherText.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    char c = char.IsUpper(letter) ? 'A' : 'a';
                    letter = (char)(((letter - shift - c + 26) % 26) + c); 
                    buffer[i] = letter;
                }
            }

            return new string(buffer);
        }
    }

}
