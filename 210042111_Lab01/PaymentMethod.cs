using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210042111_Lab01
{
    public interface PaymentMethod
    {
        void processPayment(double amount);
    }


    public class CreditCard : PaymentMethod
    {
        public string cardNumber { get; set; }
        public string cardHolderName { get; set; }

        public void processPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} via Credit Card {cardNumber}.");
            
        }
    }

    public class DigitalWallet : PaymentMethod
    {
        public string walletId { get; set; }

        public void processPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} via Digital Wallet (ID: {walletId}).");
          
        }
    }

}
