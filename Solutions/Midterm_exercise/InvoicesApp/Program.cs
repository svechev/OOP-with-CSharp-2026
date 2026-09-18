using Utilities;

namespace InvoicesApp
{
    public class Program
    {
        public static Random rand = new Random();
        public static void Main(string[] args)
        {
            InvoiceDetail[] details = new InvoiceDetail[10];
            for (int i = 0; i < details.Length; i++)
            {
                int num = rand.Next(5000);
                decimal dbl = num / 100M;
                details[i] = new InvoiceDetail(dbl);
            }

            IOutgoing in1 = new Invoice([details[0]]);
            IReceivable in2 = new Invoice([details[1]]);

            ((Invoice)in1).AddAllInvoice(details);


            List<Invoice> myInvoices = [(Invoice)in1, (Invoice)in2];

            Invoice.PrintInvoices(myInvoices);

            Console.WriteLine($"\nin1 == in2: {in1.Equals(in2)}");
            Console.WriteLine();
            Console.WriteLine(in1);
            Console.WriteLine(in2);
        }
    }
}