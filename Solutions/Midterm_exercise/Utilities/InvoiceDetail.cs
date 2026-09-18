using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class InvoiceDetail
    {
        decimal dblLineTotal;

        public decimal DblLineTotal
        {
            get => dblLineTotal;
            set => dblLineTotal = value >= 0 ? value : 0;
        }

        public InvoiceDetail(decimal dblLineTotal)
        {
            DblLineTotal = dblLineTotal;
        }

        public override string ToString()
         => $"{dblLineTotal:C2}";
    }
}
