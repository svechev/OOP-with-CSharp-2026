using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeServices
{
    public class Product
    {
        public string ID;
        private static int counter = 1;

        private Category productCategory;
        private int qty;
        private int reorderLvl;

        public Category ProductCategory
        {
            get => productCategory;
            set => productCategory = value;
        }

        public int Qty
        {
            get => qty;
            set => qty = value > 0 ? value : 0;
        }

        public int ReorderLvl
        {
            get => reorderLvl;
            set => reorderLvl = value > 0 ? value : 0;
        }


        public Product(Category _productCategory, int _qty, int _reorderLvl)
        {
            productCategory = _productCategory;
            qty = _qty;
            reorderLvl = _reorderLvl;

            ID = $"p-{counter++:D4}";
        }

        public Product(Product other) : this(other.productCategory, other.qty, other.reorderLvl)
        {

        }

        public override string ToString()
        {
            string category = productCategory switch
            {
                Category.SOFTWARE => "software",
                Category.HADRDWARE => "hardware",
                Category.EBOOKS => "ebook",
                _ => ""
            };
            return $"ID: {ID}, Category: {category}, Quantity: {qty}, Reorder level: {reorderLvl}";
        }
    }
}
