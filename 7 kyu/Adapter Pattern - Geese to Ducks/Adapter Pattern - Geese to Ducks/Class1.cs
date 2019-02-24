namespace AdapterPattern
{
    public class GooseToIDuckAdapter : IDuck
    {
        Goose goose;
        public GooseToIDuckAdapter(Goose goose)
        {
            this.goose = goose;
        }

        public void Fly()
        {
            goose.Fly();
        }

        public string Quack()
        {
            return goose.Honk();
        }
    }

    public interface IDuck
    {
        string Quack();
        void Fly();
    }

    public class Goose
    {
        public string Honk()
        {
            return "Honk";
        }
        public void Fly()
        {
            
        }
    }
}