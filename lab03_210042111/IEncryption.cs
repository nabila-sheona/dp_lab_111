using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02_210042111
{
    public interface IEncryption
    {
        string Encrypt(string text);
        string Decrypt(string text);

    }
}
