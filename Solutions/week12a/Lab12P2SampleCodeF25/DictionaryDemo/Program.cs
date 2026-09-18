using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12SampleCode
{
    public class DictionaryDemo
    {

        public static void Main()
        {

            IDictionary<Person, BankAccount> bankMap =
              new Dictionary<Person, BankAccount>(new PersonComparer());

            // Make bank accounts and person objects
            BankAccount ba1 = new  ("Kurt", 0.01),
            ba2 = new  ("Maria", 0.02),
            ba3 = new  ("Francoi", 0.03),
            ba4 = new  ("Unknown", 0.04),
            ba5 = new  ("Anna", 0.05);

            Person p1 = new ("Kurt"),
                   p2 = new ("Maria"),
                   p3 = new ("Francoi");

            ba1.Deposit(100); ba2.Deposit(200); ba3.Deposit(300);

            // Populate the bankMap: 
            bankMap.Add(p1, ba1);
            bankMap.Add(p2, ba2);
            bankMap.Add(p3, ba3);
            ReportDictionary("Initial map", bankMap);

            // Print Kurt's entry in the map:
            Console.WriteLine("{0}\n", bankMap[p1]);

            // Mutate Kurt's entry in the map
            bankMap[p1] = ba4;
            ReportDictionary("bankMap[p1] = ba4;", bankMap);

            // Mutate Maria's entry in the map. PersonComparer crucial!
            ba4.Deposit(400);
            bankMap[new Person("Maria")] = ba4;
            ReportDictionary("ba4.Deposit(400);  bankMap[new Person(\"Maria\")] = ba4;", bankMap);

            // Add p3 yet another time to the map
            // Run-time error: An item with the same key has already been added.
            /*  bankMap.Add(p3, ba1);
                ReportDictionary("bankMap.Add(p3, ba1);", bankMap); 
             */

            // Try getting values of some given keys
            BankAccount? ba1Res  ,
                         ba2Res  ;
            bool res1  ,
                 res2  ;
            res1 = bankMap.TryGetValue(p2, out ba1Res);
            res2 = bankMap.TryGetValue(new Person("Anders"), out ba2Res);
            Console.WriteLine("Account: {0}. Boolean result {1}", ba1Res, res1);
            Console.WriteLine("Account: {0}. Boolean result {1}", ba2Res, res2);
            Console.WriteLine();

            // Remove an entry from the map
            bankMap.Remove(p1);
            ReportDictionary("bankMap.Remove(p1);", bankMap);

            // Remove another entry - works because of PersonComparer
            bankMap.Remove(new Person("Francoi"));
            ReportDictionary("bankMap.Remove(new Person(\"Francoi\"));", bankMap);
        }

        public static void ReportDictionary<K, V>(string explanation,
                                                  IDictionary<K, V> dict)
        {
            Console.WriteLine(explanation);
            foreach (KeyValuePair<K, V> kvp in dict)
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            Console.WriteLine();
        }
    }

    public class PersonComparer : IEqualityComparer<Person>
    {

        public bool Equals(Person? p1, Person? p2)
        {
            return (p1!.Name == p2!.Name);
        }

        public int GetHashCode(Person p)
        {
            return p.Name.GetHashCode();
        }
    }
}
