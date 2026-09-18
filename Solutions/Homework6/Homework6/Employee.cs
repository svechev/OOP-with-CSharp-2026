using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Homework6
{
    public class Employee : EventArgs
    {
        #region Data members
        private string name;
        private Store worksAt;
        #endregion

        #region Constructors
        public Employee(string name)
        {
            Name = name;
        }
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set
            {
                name = value ?? "";
            }
        }

        public Store WorksAt
        {
            get => worksAt;
            set
            {
                worksAt = value;
            }
        }
        #endregion

        #region Utility methods
        public virtual void GetAppointed(object sender, EventArgs e)
        {
            Store newStore = (Store)sender;
            worksAt = newStore;

            Console.WriteLine($"{GetType().Name} appointed to {worksAt.STORE_NAME}");
        }

        internal void ManageListOfProducts(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListOfProducts")
            {
                Console.WriteLine($"Assigned new list of products to {worksAt.STORE_NAME}");

                Console.WriteLine(
                    $"{GetType().Name}: {e.PropertyName}"
                );
            }
        }

        public void ManageQty(Product p, int qty)
        {
            int index = worksAt.ListOfProducts.IndexOf(p);

            worksAt.OnUpdateQuantity(index, qty);
        }

        public override string ToString()
         => $"Employee {name}, works at {worksAt.STORE_NAME}"; 
        #endregion
    }
}