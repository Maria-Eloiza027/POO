namespace POO;

public class Vaca : Animal
{
    public Vaca(string nome, int idade) : base(nome, idade)
    {
    }

    public override void FazerBarulho()
    {
        Console.WriteLine($"{Nome} fez Muuuu");
    }
}