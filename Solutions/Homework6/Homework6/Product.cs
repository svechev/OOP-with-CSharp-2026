using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework6
{
    public class Product
    {
        #region Data members
        private string description;
        private int quantity;
        #endregion

        #region Properties
        public string Description
        {
            get => description;
            set
            {
                description = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value > 0 ? value : 0;
            }
        }
        #endregion

        #region Constructors
        public Product(string description, int quantity)
        {
            Description = description;
            Quantity = quantity;
        }

        public Product() : this("Product", 1)
        {

        }

        public Product(Product other) : this(other.description, other.quantity)
        {

        }
        #endregion

        #region Utility methods
        public override string ToString()
         => $"{description}: {quantity}"; 
        #endregion
    }
}