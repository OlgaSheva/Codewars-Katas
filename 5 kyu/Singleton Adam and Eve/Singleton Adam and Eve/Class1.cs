using System;

namespace Singleton_Adam_and_Eve
{
    sealed public class Adam : Male
    {
        private static Adam instance;

        private Adam() : base("Adam") { }

        public static Adam GetInstance()
        {
            if (instance == null)
                instance = new Adam();
            return instance;
        }
    }

    sealed public class Eve : Female
    {
        private static Eve instance;
        
        private Eve(Male adam) : base("Eve") { }

        public static Eve GetInstance(Male adam)
        {
            if (adam == null)
                throw new ArgumentNullException();
            if (instance == null)
                instance = new Eve(adam);
            return instance;
        }
    }

    public class Male : Human
    {
        protected Male(string name) : base(name) { }
        public Male(string name, Female mother, Male father) : base(name, mother, father) { }
    }
    public class Female : Human
    {
        protected Female(string name) : base(name) { }
        public Female(string name, Female mother, Male father) : base(name, mother, father) { }
    }
    public abstract class Human
    {
        public string Name { get; set; }
        public Male Father { get; set; }
        public Female Mother { get; set; }

        protected Human(string name)
        {
            this.Name = name;
        }

        public Human(string name, Female mother, Male father) : this(name)
        {
            if (mother == null || father == null)
                throw new ArgumentNullException();

            this.Mother = mother;
            this.Father = father;
        }
    }
}
