using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210042111_Lab01
{
    public class SetPayment
    {
        IPaymentMethod paymentMethod;


        public IPaymentMethod SetPaymentType()
        {
            Console.WriteLine("Choose a payment method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Digital Wallet");
            Console.WriteLine("3. Bkash");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter card number:");
                    string cardNumber = Console.ReadLine();
                    Console.WriteLine("Enter cardholder name:");
                    string cardHolderName = Console.ReadLine();
                    paymentMethod = new CreditCard(cardNumber, cardHolderName);
                    break;
                case 2:
                    Console.WriteLine("Enter wallet number:");
                    string walletId = Console.ReadLine();
                    paymentMethod = new DigitalWallet(walletId);
                    break;
                case 3:
                    Console.WriteLine("Enter phone number:");
                    string phone = Console.ReadLine();
                    paymentMethod = new Bkash(phone);
                    break;
                default:
                    Console.WriteLine("Invalid choice, no payment method selected.");
                    return null;
            }

            return paymentMethod;




        }
    }
}
