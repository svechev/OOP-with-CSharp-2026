using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Homework6
{
    public class Manager : Employee
    {
        #region Constructors
        public Manager(string name) : base(name)
        {

        }
        #endregion


        #region Utility methods
        internal void ManageProductQuantity(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ProductQuantity")
            {
                Console.WriteLine(
                    $"Manager: {e.PropertyName}"
                );
            }
        }

        public override string ToString()
        => $"Manager {Name}, works at {WorksAt.STORE_NAME}"; 
        #endregion
    }
}