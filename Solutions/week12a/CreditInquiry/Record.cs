using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInquiry
{
    [Serializable]
    public readonly record struct Record(int Account, string FirstName, string LastName, decimal Balance) { };

} // end namespace BankLibrary
 
