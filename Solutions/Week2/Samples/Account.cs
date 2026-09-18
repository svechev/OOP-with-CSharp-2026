using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Account(DateTime dateTime,  // Date created
                          decimal balance,    // Account balance
                          double aRate,       // Annual rate 
                          string id           // Account ID
                            )
    {
        #region Properties
        public decimal Balance { get; set; } = balance;
        public double AnnualInterestRate { get; set; } = aRate;
        public DateTime DateCreated { get; set; } = dateTime;
        public required string Id { get; init; } = id;
        #endregion

        #region Utility methods
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
            }
        } 
        #endregion

        public override string ToString()
         => $"ID: {Id} Balance: {Balance:C} Interest Rate: {AnnualInterestRate} " +
            $"Date: {DateCreated}";
    }
}
