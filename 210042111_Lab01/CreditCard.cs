using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _210042111_Lab01
{

    
    public class CreditCard : IPaymentMethod
    {
        public string cardNumber { get; set; }
        public string cardHolderName { get; set; }

        public CreditCard(string cardNumber, string cardHolderName)
        {
            this.cardNumber = cardNumber;
            this.cardHolderName = cardHolderName;
        }
        public void ProcessPayment()
        {
            Console.WriteLine($"Processing payment via credit card.  number: {cardNumber}");
        }
        public void processPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} via Credit Card {cardNumber}.");
        }
    }

  
    public class Bkash : IPaymentMethod
    {
        public string phoneNumber { get; set; }

      
        public Bkash(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public void ProcessPayment()
        {
            Console.WriteLine($"Processing payment via Bkash. Phone number: {phoneNumber}");
        }
        public void processPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} via Bkash account {phoneNumber}.");
        }
    }

   


}
