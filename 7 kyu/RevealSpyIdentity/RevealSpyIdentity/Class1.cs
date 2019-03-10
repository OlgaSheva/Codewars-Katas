using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevealSpyIdentity
{
    public abstract class Human
    {
        public string Name { get; set; }
    }

    public class Police : Human { }

    public class Spy : Human { }

    public class Kata
    {
        public static string FindHisIdentity(Human person)
        {
            if (person is Police)
                return $"{person.Name} is a Police";
            else if (person is Spy)
                return $"{person.Name} is a Spy";
            else return null;
        }
    }
}
