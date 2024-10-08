﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _210042111_Lab01
{
   
    public class DigitalWallet : IPaymentMethod
    {
        public string walletId { get; set; }

        public DigitalWallet(string walletId)
        {
            this.walletId = walletId;
        }
        public void ProcessPayment()
        {
            Console.WriteLine($"Processing payment via Digital wallet. number: {walletId}");
        }
        public void processPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} via Digital Wallet {walletId}.");
        }
    }
}
