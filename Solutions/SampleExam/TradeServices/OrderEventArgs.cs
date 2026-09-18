using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeServices
{
    delegate void OrderHandler();
    public class OrderEventArgs : EventArgs
    {
        public string ID { get; set; }
        public int Qty { get; set; }
        public OrderEventArgs(string _ID, int qty) : base()
        {
            ID = _ID;
            Qty = qty;
        }
    }
}
