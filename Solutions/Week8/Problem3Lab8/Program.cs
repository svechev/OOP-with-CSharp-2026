using Problem3Lab8;
using System.Collections;
using System.Runtime.CompilerServices;


ArrayList details = new ArrayList();
for  (int i = 0; i < 10; i++)
{
    details.Add(new InvoiceDetails(i));
}

Invoice i1 =  new Invoice(details.GetRange(0, 5));
i1.PrintInvoice();

Invoice i2 =  new Invoice(details.GetRange(5, 5));
i2.PrintInvoice();

Invoice i3 = i1 + i2;
i3.PrintInvoice();

delegate void myDel(Invoice i);

myDel instance = new();