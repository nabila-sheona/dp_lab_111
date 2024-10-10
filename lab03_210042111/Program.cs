using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02_210042111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EncryptionContext encryptionContext = new EncryptionContext();
            string key, inputFile, outputFile;
            

            Console.WriteLine("Select an encryption method:" +
                "\n1. AES" +
                "\n2. DES" +
                "\n3. Caesar Cipher");

            string choice = Console.ReadLine();

            Console.WriteLine("Enter the input file path:");
            inputFile = Console.ReadLine();
            string plainText = FileHandler.Read(inputFile);

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter a 16-character key for AES:");
                    key = Console.ReadLine();
                    encryptionContext.SetEncryptionStrategy(new AESEncryption(key));
                    break;

                case "2":
                    Console.WriteLine("Enter an 8-character key for DES:");
                    key = Console.ReadLine();
                    encryptionContext.SetEncryptionStrategy(new DESEncryption(key));
                    break;

                case "3":
                  
                    encryptionContext.SetEncryptionStrategy(new CaesarCipher());
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }


            Console.WriteLine("Enter the output file path:");
            outputFile = Console.ReadLine();
            string encryptedText = encryptionContext.EncryptText(plainText);
            FileHandler.Write(outputFile, encryptedText);

           
            string decryptedText = encryptionContext.DecryptText(encryptedText);
           
            Console.ReadKey();
        }
    }
}