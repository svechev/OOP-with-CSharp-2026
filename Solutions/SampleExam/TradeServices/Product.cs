using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TradeServices
{
    public class Product
    {
        #region Data members
        private static int count = 1;

        public string ID;
        private Category productCategory;
        private int qty;
        private int reorderLevel; 
        #endregion

        #region Properties
        public Category ProductCategory
        {
            get => productCategory;
            set => productCategory = value;
        }

        public int Qty
        {
            get => qty;
            set => qty = value;
        }

        public int ReorderLevel
        {
            get => reorderLevel;
            set => reorderLevel = value;
        } 
        #endregion

        public Product(Category _productCategory, int _qty, int _reorderLevel) {
            productCategory = _productCategory;
            qty = _qty;
            reorderLevel = _reorderLevel;

            ID = $"P-{count++:D4}";
        }

        public Product(Product other) : this(other.ProductCategory, other.Qty, other.ReorderLevel) { }

        public override string ToString()
        => $"Product {ID}: {productCategory}, quantity {qty}, reorder level {reorderLevel}";
    }
}
