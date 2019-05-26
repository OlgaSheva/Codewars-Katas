using System;
using System.Collections.Generic;

namespace EventAndDelegate
{
    public class Program
    {
        public static void Main()
        {
            List<string> peopleList = new List<string>()
            {
                "Peter", "Mike", "Peter", "Bob", "Peter", "Peter", "Bob", "Mike",
                "Bob", "Peter", "Peter", "Mike", "Bob"
            };
            Publisher publisher = new Publisher();
            publisher.ContactNotify += TextMessageSend.Send;
            publisher.CountMessages(peopleList);
            string expected = "Peter, Bob, Peter, Mike";

            Console.ReadKey();
        }
    }

    // send text message
    public class TextMessageSend
    {
        public static void Send(object source, PersonEventArgs e)
        {
            Console.WriteLine(e.Name);
        }
    }



    public class PersonEventArgs : EventArgs
    {
        public string Name { get; set; }     
    }

    public class Publisher
    {
        public event EventHandler<PersonEventArgs> ContactNotify;

        Dictionary<string, int> dic = new Dictionary<string, int>();
        int i = 0;

        public void CountMessages(List<string> peopleList)
        {
            foreach (string person in peopleList)
            {
                // implement your logic to send name of people after apearing 3*n times
                if (!dic.ContainsKey(person))
                {
                    dic.Add(person, 1);
                }
                else
                {
                    foreach (string name in dic.Keys)
                    {
                        if (person == name)
                        {
                            dic[name] += 1;
                            if (dic[name] % 3 == 0)
                            {
                                PersonEventArgs p = new PersonEventArgs();
                                p.Name = person;
                                OnContactNotify(p); // Notify subscribers
                            }
                            break;
                        }                        
                    }
                }
            }
        }

        protected virtual void OnContactNotify(PersonEventArgs e)
        {
            EventHandler<PersonEventArgs> sender = ContactNotify;
            if (sender != null)
            {
                sender(this, e);
            }
        }
    }
}
