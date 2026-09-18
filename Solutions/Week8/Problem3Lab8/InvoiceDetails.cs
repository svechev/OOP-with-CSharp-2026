using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3Lab8
{
    public class InvoiceDetails
    {
        double lineTotal;

        public double LineTotal
        {
            get => lineTotal;
        }

        public InvoiceDetails(double total)
        {
            lineTotal = total;
        }

        public InvoiceDetails() : this(0)
        {

        }

        public InvoiceDetails(InvoiceDetails other) : this(other.lineTotal)
        {

        }

        public override string ToString()
        => $"{lineTotal}";
    }
}
