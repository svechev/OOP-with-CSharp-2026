using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Homework6
{
    public class Store : INotifyPropertyChanged
    {
        #region Data members
        private static int cnt;
        private List<Product> listOfProducts;
        private Manager manager;
        public string STORE_NAME;
        private Employee worker;

        public event EventHandler? Appoint;
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        public Employee Worker
        {
            get => worker;
            set
            {
                worker = value;
            }
        }
        public List<Product> ListOfProducts
        {
            get => listOfProducts;
            set
            {
                List<Product> listDeepCopy = new List<Product>();
                foreach (Product product in value)
                {
                    listDeepCopy.Add(new Product(product));
                }
                listOfProducts = listDeepCopy;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListOfProducts)));
            }
        }
        #endregion

        #region Constructors
        public Store()
        {
            cnt++;
            STORE_NAME = "Store " + cnt;
        }
        #endregion

        #region Utility methods
        // Appointing an employee
        public void OnAppointment(Employee employee)
        {
            // Appoint the employee
            if (employee is Manager m)
            {
                manager = m;
                Console.WriteLine($"{STORE_NAME}: Appointed manager {m.Name}.");
            }

            else
            {
                worker = employee;
                Console.WriteLine($"{STORE_NAME}: Appointed employee {employee.Name}.");
            }

            // Employee/manager subscribes
            Appoint += employee.GetAppointed!;
            PropertyChanged += employee.ManageListOfProducts!;

            // Special case for manager
            if (employee is Manager managerEmployee)
            {
                PropertyChanged += managerEmployee.ManageProductQuantity!;
            }

            // Trigger Appoint event
            Appoint?.Invoke(this, new EventArgs());

            // Unsubscribe, because employee is already appointed
            Appoint -= employee.GetAppointed!;
        }

        // Handles quantity changes - displays information, triggers property changed
        public void OnUpdateQuantity(int index, int newQty)
        {
            Console.WriteLine("Changed quantity.");

            Product product = ListOfProducts[index];
            Console.WriteLine($"{product} Prev qty: {product.Quantity}, New qty: {newQty}");

            product.Quantity = newQty;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductQuantity"));

        }


        public override string ToString()
        => $"Products in {STORE_NAME}:\n{string.Join("\n", listOfProducts)}"; 
        #endregion

    }
}