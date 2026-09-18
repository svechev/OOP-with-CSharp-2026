using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeServices
{
    public delegate void OrderHandler();
    public class OrderEventArgs : EventArgs
    {
        public string ProductID { get; set; }
        public int Qty { get; set; }
        public OrderEventArgs(string ID, int _qty)
        {
            ProductID = ID;
            Qty = _qty;
        }
    }
}
