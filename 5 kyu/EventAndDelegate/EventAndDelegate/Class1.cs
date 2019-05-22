using System;
using System.Collections.Generic;

namespace EventAndDelegate
{
    public delegate string TextMessageSend(string name);

    public class PersonEventArgs : EventArgs
    {
        // implement cusotm event handler wiht Name property (string)
               
        public string Name { get; set; }

        public string ContactNotify(string name)
        {
            this.Name = name;
            return Name;
        }        
    }

    public class Publisher
    {
        public event TextMessageSend ContactNotify;

        Dictionary<string, int> dic = new Dictionary<string, int>();
        int i = 0;

        public void CountMessages(List<string> peopleList)
        {
            foreach (string person in peopleList)
            {
                // implement your logic to send name of people after apearing 3*n times
                foreach (string name in dic.Keys)
                {
                    if (person == name)
                    {
                        dic.ContainsKey(person);
                    }
                    else
                    {
                        dic.Add(person, 1);
                    }
                }

                OnContactNotify(person); // Notify subscribers
            }
        }
    }
}
