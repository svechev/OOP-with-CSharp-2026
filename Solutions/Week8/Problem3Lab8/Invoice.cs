using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem3Lab8
{
    public class Invoice
    {
        ArrayList detailLines;
        long invoiceNumber;
        static long count = 0;

        public long InvoiceNumber
        {
            get => invoiceNumber;
        }

        public Invoice(ArrayList detailLines)
        {
            this.detailLines = new ArrayList(detailLines);
            invoiceNumber = count++;
        }

        public Invoice() : this(new ArrayList())
        {

        }

        public Invoice(Invoice other) : this(other.detailLines)
        {

        }

        public void PrintInvoice()
        {
            Console.WriteLine($"{invoiceNumber}: {string.Join(", ", detailLines.ToArray())}");
        }

        public static Invoice operator+(Invoice left, Invoice right)
        {
            ArrayList combined = left.detailLines;
            combined.InsertRange(combined.Count, right.detailLines);
            return new Invoice(combined);
        }
    }
}
