using System;

public class GooseToIDuckAdapter
{
    public GooseToIDuckAdapter(Goose goose)
    {
    }
}

public interface IDuck
{
    string Quack();
    void Fly();
}

public class Goose
{
    string Honk();
    void Fly();
}
