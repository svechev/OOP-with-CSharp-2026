using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    public class Invoice
    {
        #region Data members
        private string partNumber;
        private string partDescription;
        private decimal pricePerItem;
        private int quantity;
        #endregion

        #region Constructors
        public Invoice(string partDescription, string partNumber, decimal pricePerItem, int quantity)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Properties
        public string PartDesctiption
        {
            get => partDescription;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    partDescription = value;
                }
            }
        }

        public string PartNumber
        {
            get => partNumber;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    partNumber = value;
                }
            }
        }

        public decimal PricePerItem
        {
            get => pricePerItem;
            set
            {
                if (value > 0)
                {
                    pricePerItem = value;
                }
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value >= 0)
                {
                    quantity = value;
                }
            }
        }
        #endregion

        #region Utility method
        public decimal GetInvoiceAmount()
         => pricePerItem * quantity;

        // decimal * int => ok
        // decimal * double => requires casting 
        // 100m * (decimal) 1.5
        public decimal GetInvoiceAmountWithDiscount(double discount)
         => quantity switch
         {
             int q when q < 100 && q > 0 => pricePerItem * quantity,
             int q when q >= 100 => pricePerItem * quantity * (decimal)discount,
             _ => throw new ArgumentException()
         };
            
        #endregion


        public override string ToString()
        => $"PartDesc:{PartDesctiption} PartNum:{PartNumber} " +
            $"PPI:{PricePerItem} Quantity:{Quantity}";
    }
}
