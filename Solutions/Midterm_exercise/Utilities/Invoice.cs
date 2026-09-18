using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Invoice : IReceivable, IOutgoing
    {
        // data members
        #region Data members
        readonly long INVOICE_NUMBER;
        static long count = 0;
        InvoiceDetail[] invoiceItems;
        #endregion

        // properties
        #region Properties
        public long InvoiceNumber
        {
            get => INVOICE_NUMBER;
        }

        public InvoiceDetail[] InvoiceItems
        {
            get
            {
                InvoiceDetail[] copiedInvoiceItems = new InvoiceDetail[invoiceItems.Length];
                for (int i = 0; i < copiedInvoiceItems.Length; i++)
                {
                    copiedInvoiceItems[i] = new InvoiceDetail(invoiceItems[i].DblLineTotal);
                }
                return copiedInvoiceItems;
            }
            set
            {
                // empty array
                if (value.Length == 0)
                {
                    invoiceItems = new InvoiceDetail[invoiceItems.Length];
                    return;
                }

                // non-empty array
                invoiceItems = new InvoiceDetail[value.Length];
                for (int i = 0; i < invoiceItems.Length; i++)
                {
                    invoiceItems[i] = new InvoiceDetail(value[i].DblLineTotal);
                }
            }

        }

        // explicit implementations of invoice total
        decimal IReceivable.InvoiceTotal => InvoiceTotal();

        decimal IOutgoing.InvoiceTotal => InvoiceTotal() * -1;
        #endregion


        // general purpose constructor
        #region Constructor
        public Invoice(InvoiceDetail[] _invoiceItems)
        {
            INVOICE_NUMBER = ++count;

            invoiceItems = _invoiceItems;
        }
        #endregion


        #region Utility methods
        // invoice total method
        public decimal InvoiceTotal()
         => invoiceItems.Sum(invDet => invDet.DblLineTotal);

        public static void PrintInvoices(List<Invoice> invoices)
        {
            foreach (Invoice invoice in invoices)
            {
                // sort the invoice details
                var sortedDetails = invoice.invoiceItems
                    .Select(item => item.DblLineTotal).OrderDescending();

                // display details
                Console.WriteLine($"Invoice number {invoice.InvoiceNumber}");
                foreach (var detail in sortedDetails)
                {
                    Console.WriteLine($"{detail:C2}");
                }

                // print invoice total (outgoing/receivable)

            }

        }


        public override bool Equals(object? obj)
        {
            if (obj is Invoice i)
            {
                return this.InvoiceTotal() == i.InvoiceTotal();
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string toReturn = $"{INVOICE_NUMBER}: [";
            for (int i = 0; i < invoiceItems.Length - 1; i++)
            {
                toReturn += $"{invoiceItems[i]}, ";
            }
            return toReturn + $"{invoiceItems[invoiceItems.Length - 1]}]";
        }

        // maybe?
        public override int GetHashCode()
        {
            return (int)this.InvoiceTotal();
        } 
        #endregion
    }

    // class for extenstion method
    public static class InvoiceExtensions
    {
        public static void AddAllInvoice(this Invoice inv, InvoiceDetail[] newItems)
        {
            List<InvoiceDetail> newList = new(inv.InvoiceItems);
            newList.AddRange(newItems);
            inv.InvoiceItems = newList.ToArray();
        }
    }
}
