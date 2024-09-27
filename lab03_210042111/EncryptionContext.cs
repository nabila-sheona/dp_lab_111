using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02_210042111
{
    public class EncryptionContext
    {
        private IEncryption strategy;

        public void SetEncryptionStrategy(IEncryption strategy)
        {
           this.strategy = strategy;
        }

        public string EncryptText(string plainText)
        {
            return strategy.Encrypt(plainText);
        }

        public string DecryptText(string cipherText)
        {
            return strategy.Decrypt(cipherText);
        }

    }

}
