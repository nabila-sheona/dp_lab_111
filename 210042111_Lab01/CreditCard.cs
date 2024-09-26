﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210042111_Lab01
{

    
    public class CreditCard : IPaymentMethod
    {
        public string cardNumber { get; set; }
        public string cardHolderName { get; set; }

        // Constructor for CreditCard
        public CreditCard(string cardNumber, string cardHolderName)
        {
            this.cardNumber = cardNumber;
            this.cardHolderName = cardHolderName;
        }

        public void processPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} via Credit Card {cardNumber}.");
        }
    }

    // Bkash Class (moved out of CreditCard)
    public class Bkash : IPaymentMethod
    {
        public string phoneNumber { get; set; }

        // Constructor for Bkash
        public Bkash(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void processPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} via Bkash account {phoneNumber}.");
        }
    }

   


}