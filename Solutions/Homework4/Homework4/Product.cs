using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    internal class Product
    {
        #region Data members
        private static long cnt = 1;
        public string ID;
        private static Random rnd = new Random();
        public List<int> WeeklyPurchases;
        #endregion

        #region Properties
        public Type Category {  get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public YearlyQuarter Quarter { get; set; }
        #endregion

        #region Constructors
        // General purpose constructor for class Product
        public Product(string description, Type category, List<int> weeklyPurchases, decimal price)
        {
            // Use the function parameters for initialization
            Description = description;
            Category = category;
            WeeklyPurchases = weeklyPurchases;
            Price = price;

            // Assign a random number to quarter
            Quarter = (YearlyQuarter)rnd.Next(1, 5);

            // Assign the next available ID
            long nextId = cnt++;
            ID = $"{Category}{nextId.ToString("D6")}";
        }
        #endregion

        #region Utility methods
        // ToString method for class Product
        public override string ToString()
         => $"{ID}: {string.Join(", ", WeeklyPurchases.ToArray())}"; 
        #endregion
    }
}
